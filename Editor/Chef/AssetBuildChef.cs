/*
 * Author: CharSui
 * Created On: 2024.11.04
 * Description: Let you look is busy in building a very LARGE project.
 * oh no bro, it will FREEZE a long time.LOL :)
 */

using System;
using UnityEngine;

namespace CharSuiKitchen
{
	public class AssetBuildChef : BaseChef
	{
		// 需要遍历的资源文件夹
		private string folderPath = "Assets/AddressableLearn/";

		// 15Min
		private int forceEndTime = 900000;

		#region Log & BarData

		// 参考
		// public static readonly string[] logs = new []
		// {
		// 	"Addressable content successfully built (duration : 0:12:04.241)",
		// };
		
		// public static readonly BarData[] missions = new []
		// {
		// 	new BarData(){title = "Processing Addressable Group",context = "一堆addressable的组"},
		// 	new BarData(){title = "Importing",context = "一堆Asset"},
		// 	new BarData(){title = "Hold on...",context = "Compiling scripts.."},
		// 	new BarData(){title = "Build Player Scripts",context = "只有进度条和一个Cancel"},
		// 	new BarData(){title = "Calculate Scene Dependency Datas",context = "进度条和一个Cancel，context是一系列的资源"},
		// 	new BarData(){title = "Generate Bundle Packing",context = "进度条和一个Cancel，context是一系列的资源"},
		// };
		
		#endregion

		public override void Cook(Action cookFinish)
		{
			DateTime startTime = DateTime.Now;
			// int millisecondPassed = 0;
			
			Cooker.ShowProgressBar("Hold on...","Compiling scripts..",0.0f);
			Cooker.ThreadFreeze(5000); // 5s

			var files = Cooker.GetAllFileNames(folderPath);
			var filesCount = files.Length;
			for (int i = 0; i < filesCount; i++)
			{
				var time = UnityEngine.Random.Range(100, 1000); // 0.1f ~ 1f
				var progress = UnityEngine.Random.Range(0f, 0.5f);
				Cooker.ShowProgressBar("Importing",files[i],progress);
				Cooker.ThreadFreeze(time);
			}
			
			// Cooker.ThreadFreeze(Cooker.milliseconds_ten_minutes);
			Cooker.ShowProgressBar("Hold on...","Compiling scripts..",0.3f);
			Cooker.ThreadFreeze(50000); // 50s
			
			for (int i = 0; i < filesCount; i++)
			{
				var time = UnityEngine.Random.Range(100, 1000); // 0.1f ~ 1f
				var progress = UnityEngine.Random.Range(0f, 0.5f);
				Cooker.ShowProgressBar("Calculate Scene Dependency Datas",files[i],progress);
				Cooker.ThreadFreeze(time);
			}
			
			Cooker.CloseProgressBar();

			// Log build time
			TimeSpan duration = DateTime.Now - startTime;
			string formattedDuration = string.Format("{0}:{1:D2}:{2:D2}.{3:D3}",
				(int)duration.TotalHours,
				duration.Minutes,
				duration.Seconds,
				duration.Milliseconds);
			Debug.Log($"Addressable content successfully built (duration : {formattedDuration})");
			Debug.Log($"Text build layout written to Library/com.unity.addressables/buildlayout.txt and json build layout written to\nLibrary/com.unity.addressables/BuildReports/buildlayout_{DateTime.Now:yyyy.MM.dd.HH.mm.ss}.json\nUnityEditor.GenericMenu:CatchMenu (object,string[],int)");
		}
	}
}