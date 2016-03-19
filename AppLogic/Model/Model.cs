using System;
using System.Diagnostics;

namespace AppLogic
{
	public class Model : IModel
	{
		private IView view;

		public Model(IView view)
		{
			this.view = view;
		}

		public void Test()
		{
			Debug.WriteLine ("Testing");
		}
	}
}

