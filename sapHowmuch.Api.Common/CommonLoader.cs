﻿using Autofac;
using sapHowmuch.Api.Common.Interfaces;
using System;
using System.Collections.Generic;
using System.ComponentModel.Composition.Hosting;
using System.ComponentModel.Composition.Primitives;
using System.Linq;
using System.Reflection;
using System.Text;

namespace sapHowmuch.Api.Common
{
	/// <summary>
	/// This represents the <c>ComponentLoader</c> class using by MEF.
	/// </summary>
	public static class CommonLoader
	{
		/// <summary>
		/// Load components from path.
		/// </summary>
		/// <param name="builder"><see cref="ContainerBuilder" /> instance.</param>
		/// <param name="path">module path to load.</param>
		/// <param name="pattern">search pattern to find modules</param>
		public static void LoadContainer(ContainerBuilder builder, string path, string pattern)
		{
			var directoryCatalog = new DirectoryCatalog(path, pattern);
			var importDefinition = BuildImportDefinition();

			try
			{
				using (var aggregateCatalog = new AggregateCatalog())
				{
					aggregateCatalog.Catalogs.Add(directoryCatalog);

					using (var compositionContainer = new CompositionContainer(aggregateCatalog))
					{
						IEnumerable<Export> exports = compositionContainer.GetExports(importDefinition);
						IEnumerable<IComponent> modules = exports.Select(ex => ex.Value as IComponent).Where(m => m != null);

						var registerComponent = new RegisterComponent(builder);

						foreach (IComponent module in modules)
						{
							module.Setup(registerComponent);
						}
					}
				}
			}
			catch (ReflectionTypeLoadException typeLoadException)
			{
				var stringBuilder = new StringBuilder();

				foreach (Exception loaderException in typeLoadException.LoaderExceptions)
				{
					stringBuilder.AppendFormat("{0}" + Environment.NewLine, loaderException.Message);
				}

				throw new TypeLoadException(stringBuilder.ToString(), typeLoadException);
			}
		}

		private static ImportDefinition BuildImportDefinition()
		{
			return new ImportDefinition(def => true, typeof(IComponent).FullName, ImportCardinality.ZeroOrMore, false, false);
		}
	}

	/// <summary>
	/// This represents the <c>RegisterComponent</c> class.
	/// </summary>
	internal class RegisterComponent : IRegisterComponent
	{
		private readonly ContainerBuilder _builder;

		/// <summary>
		/// Initialises a new instance of the <see cref="RegisterComponent" /> class.
		/// </summary>
		/// <param name="builder"><see cref="ContainerBuilder" /> instance.</param>
		public RegisterComponent(ContainerBuilder builder)
		{
			if (builder == null)
			{
				throw new ArgumentNullException(nameof(builder));
			}

			this._builder = builder;
		}

		/// <summary>
		/// Gets Autofac <see cref="ContainerBuilder" /> instance.
		/// </summary>
		public ContainerBuilder Builder { get { return _builder; } }
	}
}