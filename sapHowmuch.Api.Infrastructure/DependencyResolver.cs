using sapHowmuch.Api.Common.Interfaces;
using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace sapHowmuch.Api.Infrastructure
{
	[Export(typeof(IComponent))]
	public class DependencyResolver : IComponent
	{
		public void Setup(IRegisterComponent registerComponent)
		{
			// TODO: DI settings by Autofac
		}
	}
}
