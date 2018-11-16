
using System;
using System.Management;
using System.Text;
using System.IO;

namespace HardwareInfo
{
	class Program
	{
		public static void Main(string[] args)
		{
			var sb = new StringBuilder();
			using (var Win32_Processor = new ManagementObjectSearcher("select * from Win32_Processor")) {
				// https://docs.microsoft.com/en-us/windows/desktop/CIMWin32Prov/win32-processor
				foreach (var obj in  Win32_Processor.Get()) {
					try {
						sb.AppendLine("名称（Name）：" + obj["Name"]);
					} catch {
					 
					}
					try {
						sb.AppendLine("说明（Caption）：" + obj["Caption"].ToString());
					} catch {
					}
					try {
						sb.AppendLine("制造商（Manufacturer）：" + obj["Manufacturer"]);
					} catch {
					}
					try {
						sb.AppendLine("核心数（NumberOfCores）：" + obj["NumberOfCores"].ToString());
					} catch {
						
					}
					try {
						sb.AppendLine("逻辑处理器数（NumberOfLogicalProcessors）：" + obj["NumberOfLogicalProcessors"]);
					} catch {
					}
					try {
						sb.AppendLine("数据带宽（DataWidth）：" + obj["DataWidth"]+"-byte");
					} catch {
					}
					try {
						sb.AppendLine("二级缓存大小（L2CacheSize）：" + obj["L2CacheSize"] + " K");
					} catch {
					}
					try {
						sb.AppendLine("三级缓存大小（L3CacheSize）：" + obj["L3CacheSize"] + " K");
					} catch {
					}
					try {
						sb.Append("支持电源管理（PowerManagementSupported）：");
						if (obj["PowerManagementSupported"].ToString() == "False") {
							sb.AppendLine("否");
							
						} else {
							sb.AppendLine("是");
							
						}
					} catch {
	
					}
					try {
						sb.AppendLine("修订级别（Revision）：" + obj["Revision"]);
					} catch {
					}
				 
					try {
						sb.AppendLine("当前时钟频率（CurrentClockSpeed）：" + double.Parse(obj["CurrentClockSpeed"].ToString()) / 1000d + " GHz");
					} catch (Exception e) {
						sb.AppendLine(e.ToString());
					}
					
					try {
						sb.AppendLine("【AddressWidth】：" + obj["AddressWidth"].ToString());
					} catch {
						sb.AppendLine("AddressWidth");
					}
					try {
						sb.AppendLine("【Architecture】：" + obj["Architecture"].ToString());
					} catch {
						sb.AppendLine("Architecture");
					}
					 
					try {
						sb.AppendLine("【Availability】：" + obj["Availability"].ToString());
					} catch {
						sb.AppendLine("Availability");
					}
					
					try {
						sb.AppendLine("【Characteristics】：" + obj["Characteristics"].ToString());
					} catch {
						sb.AppendLine("Characteristics");
					}
					try {
						sb.AppendLine("【ConfigManagerErrorCode】：" + obj["ConfigManagerErrorCode"].ToString());
					} catch {
						sb.AppendLine("ConfigManagerErrorCode");
					}
					try {
						sb.AppendLine("【ConfigManagerUserConfig】：" + obj["ConfigManagerUserConfig"].ToString());
					} catch {
						sb.AppendLine("ConfigManagerUserConfig");
					}
					try {
						sb.AppendLine("【CpuStatus】：" + obj["CpuStatus"].ToString());
					} catch {
						sb.AppendLine("CpuStatus");
					}
					try {
						sb.AppendLine("【CreationClassName】：" + obj["CreationClassName"].ToString());
					} catch {
						sb.AppendLine("CreationClassName");
					}
				
					try {
						sb.AppendLine("【CurrentVoltage】：" + obj["CurrentVoltage"].ToString());
					} catch {
						sb.AppendLine("CurrentVoltage");
					}
					
					try {
						sb.AppendLine("【Description】：" + obj["Description"].ToString());
					} catch {
						sb.AppendLine("Description");
					}
					try {
						sb.AppendLine("【DeviceID】：" + obj["DeviceID"].ToString());
					} catch {
						sb.AppendLine("DeviceID");
					}
					try {
						sb.AppendLine("【ErrorCleared】：" + obj["ErrorCleared"].ToString());
					} catch {
						sb.AppendLine("ErrorCleared");
					}
					try {
						sb.AppendLine("【ErrorDescription】：" + obj["ErrorDescription"].ToString());
					} catch {
						sb.AppendLine("ErrorDescription");
					}
					try {
						sb.AppendLine("【ExtClock】：" + obj["ExtClock"].ToString());
					} catch {
						sb.AppendLine("ExtClock");
					}
					try {
						sb.AppendLine("【Family】：" + obj["Family"].ToString());
					} catch {
						sb.AppendLine("Family");
					}
					 
					  
					
					try {
						sb.AppendLine("【LastErrorCode】：" + obj["LastErrorCode"].ToString());
					} catch {
						sb.AppendLine("LastErrorCode");
					}
					try {
						sb.AppendLine("【Level】：" + obj["Level"].ToString());
					} catch {
						sb.AppendLine("Level");
					}
					try {
						sb.AppendLine("【LoadPercentage】：" + obj["LoadPercentage"].ToString());
					} catch {
						sb.AppendLine("LoadPercentage");
					}
					
					try {
						sb.AppendLine("【MaxClockSpeed】：" + obj["MaxClockSpeed"].ToString());
					} catch {
						sb.AppendLine("MaxClockSpeed");
					}
				
					
					try {
						sb.AppendLine("【NumberOfEnabledCore】：" + obj["NumberOfEnabledCore"].ToString());
					} catch {
						sb.AppendLine("NumberOfEnabledCore");
					}
					
					
					try {
						sb.AppendLine("【ProcessorId】：" + obj["ProcessorId"].ToString());
					} catch {
						sb.AppendLine("ProcessorId");
					}
					try {
						sb.AppendLine("【ProcessorType】：" + obj["ProcessorType"].ToString());
					} catch {
						sb.AppendLine("ProcessorType");
					}
				
					try {
						sb.AppendLine("【SocketDesignation】：" + obj["SocketDesignation"].ToString());
					} catch {
						sb.AppendLine("SocketDesignation");
					}
				
					try {
						sb.AppendLine("【UpgradeMethod】：" + obj["UpgradeMethod"].ToString());
					} catch {
						sb.AppendLine("UpgradeMethod");
					}
					 
			 


					
				}
			}
			var fileName = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Desktop), "HardwareInfo.txt");
			File.WriteAllText(fileName, sb.ToString(), new UTF8Encoding(false));
		}
	}
}