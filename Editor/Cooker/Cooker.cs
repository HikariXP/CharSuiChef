/*
 * Author: CharSui
 * Created On: 2024.11.04
 * Description: Magic Stick
 */

using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Threading;
using UnityEditor;
using UnityEngine;

#if UNITY_EDITOR

namespace CharSuiKitchen
{
	public static class Cooker
	{
		public static int milliseconds_ten_minutes = 600000;
		
		/// <summary>
		/// Freeze the main thread
		/// </summary>
		/// <param name="milliseconds"></param>
		public static void ThreadFreeze(int milliseconds)
		{
			Thread.Sleep(milliseconds);
		}

		public static void ShowProgressBar(string title, string context, float progress)
		{
			EditorUtility.DisplayProgressBar(title, context, progress);
		}
		
		public static void ShowProgressBar(BarData data, float progress)
		{
			EditorUtility.DisplayProgressBar(data.title, data.context, progress);
		}

		public static void CloseProgressBar()
		{
			EditorUtility.ClearProgressBar();
		}
		
		public static string[] GetAllFileNames(string path)
		{
			List<string> fileNames = new List<string>();
			TraverseDirectory(path, fileNames);
			return fileNames.ToArray();
		}

		static void TraverseDirectory(string path, List<string> fileNames)
		{
			// 获取该目录下的所有文件，并添加文件名
			string[] files = Directory.GetFiles(path);
			foreach (string file in files)
			{
				if (file.EndsWith(".meta")) continue; // 排除 .meta 文件

				fileNames.Add(Path.GetFileName(file)); // 仅添加文件名
			}

			// 获取该目录下的所有子文件夹，并递归调用
			string[] directories = Directory.GetDirectories(path);
			foreach (string directory in directories)
			{
				TraverseDirectory(directory, fileNames);
			}
		}
			
	}
}

#endif