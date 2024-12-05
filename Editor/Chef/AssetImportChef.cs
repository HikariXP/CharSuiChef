/*
 * Author: CharSui
 * Created On: 2024.12.05
 * Description: Reimport Asset
 */

using System;
using CharSuiKitchen;

public class AssetImportChef : BaseChef
{
	public override void Cook(Action cookFinish)
	{
		var files = Cooker.GetAllFileNames(Cooker.assetsFolderPath);
		var filesCount = files.Length;
		for (var i = 0; i < filesCount; i++)
		{
			var time = UnityEngine.Random.Range(100, 1000); // 0.1f ~ 1f
			var progress = UnityEngine.Random.Range(0f, 0.5f);
			Cooker.ShowProgressBar("Importing", files[i], progress);
			Cooker.ThreadFreeze(time);
		}
	}
}