/*
 * Copyright (c) PeroPeroGames Co., Ltd.
 * Author: CharSui
 * Created On: 2024.11.04
 * Description: Manage all chef and let them work
 *
 * Feature we need:
 * Define some Step we need : Build Asset? Import Asset? Build Player Script?
 * Set how long can one step cost : too long or endless is useless.
 * Start our rest time.
 */

using UnityEditor;

namespace CharSuiKitchen
{
	public class MainChef
	{
		[MenuItem("Help/Take a Build Break...")]
		public static void StartBuildAsset()
		{
			new AssetBuildChef().Cook(null);
		}

		[MenuItem("Help/Take a Import Break...")]
		public static void StartImportAsset()
		{
			new AssetImportChef().Cook(null);
		}
	}
}