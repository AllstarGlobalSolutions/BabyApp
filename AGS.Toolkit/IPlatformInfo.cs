using System;
namespace AGS.Toolkit
{
	public interface IPlatformInfo
	{
		string GetManufacturer();
		string GetModel();
		string GetVersion();
		string GetOS();
	}
}

