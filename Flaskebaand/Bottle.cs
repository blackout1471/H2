using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Flaskebaand
{
	/// <summary>
	/// The bottle object
	/// </summary>
    public class Bottle
    {
		/// <summary>
		/// The name / Brand of the bottle
		/// </summary>
		public string Name
		{
			get { return name; }
			private set { name = value; }
		}
		private string name;


		public Bottle(string name)
		{
			Name = name;
		}

	}
}
