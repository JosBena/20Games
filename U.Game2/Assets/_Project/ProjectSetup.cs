using System;
using System.Collections.Generic;
using System.IO;
using System.Net.Http;
using System.Threading.Tasks;
using UnityEditor;
using UnityEditor.PackageManager;
using UnityEditor.PackageManager.Requests;
using UnityEngine;
using UnityEngine.UIElements;
using static System.IO.Path;
using static UnityEditor.AssetDatabase;

public static class ProjectSetup {

	[MenuItem("Tools/Setup/Import Essential Assets")]
	private static void ImportEssentials() {
		Dictionary<string, string> AssetList = new Dictionary<string, string>() {
			{"PrimeTween High-Performance Animations and Sequences.unitypackage" , "Kyrylo Kuzyk/Editor ExtensionsAnimation" },
			{"Selection History.unitypackage","Staggart Creations/Editor ExtensionsUtilities" },
			{"Better Hierarchy.unitypackage","Toaster Head\\Editor ExtensionsUtilities" },
			{"Audio Preview Tool.unitypackage","Warped Imagination\\Editor ExtensionsAudio" }
		};
		foreach (var key in AssetList) Assets.ImportAsset(key.Key, key.Value);
	}

	[MenuItem("Tools/Setup/Import Essential Packages")]
	public static void InstallPackages() {
		//Odin Inspector, Unit Tasks, Primetween
		string[] packages = {
			"com.unity.inputsystem",
			"git+https://github.com/Cysharp/UniTask.git?path=src/UniTask/Assets/Plugins/UniTask" };
		Packages.InstallPackage(packages);
	}

	[MenuItem("Tools/Setup/Import Essential Packages 2D")]
	public static void InstallPackages2D() {
		string[] packages = {
			"com.unity.feature.2d"
		};
		Packages.InstallPackage(packages);
	}

	[MenuItem("Tools/Setup/Create Folders")]
	public static void CreateFolders() {
		Folders.Create("_Project", "Animation", "Art", "Materials", "Prefabs", "_Scripts/Tests/Editor", "_Scripts/Tests/RunTime");
		Refresh();
		Folders.Move("_Project", "Scenes");
		Folders.Move("_Project", "Settings");
		Folders.Delete("TutorialInfo");
		Refresh();

		const string pathToInputActions = "Assets/InputSystem_Actions.inputactions";
		string destination = "Assets/_Project/Settings/InputSystem_Actions.inputActions";
		MoveAsset(pathToInputActions, destination);

		const string pathToReadme = "Assets/Readme.asset";
		DeleteAsset(pathToReadme);
		Refresh();
	}

	[MenuItem("Tools/Setup/Import All", priority = -1)]
	public static void ImportAll() {
		CreateFolders();
		InstallPackages2D();
		InstallPackages();
		ImportEssentials();
	}

	private static class Assets {

		public static void ImportAsset(string asset, string folder) {
			string basePath = System.Environment.GetFolderPath(System.Environment.SpecialFolder.ApplicationData);
			string assetsFolder = Combine(basePath, "Unity/Asset Store-5.x");

			ImportPackage(Combine(assetsFolder, folder, asset), false);
		}
	}

	private static class Packages {
		private static AddRequest request;
		private static Queue<string> packagesToInstall = new Queue<string>();

		private static async void StartNextPackageInstallation() {
			request = Client.Add(packagesToInstall.Dequeue());

			while (!request.IsCompleted) await Task.Delay(10);

			if (request.Status == StatusCode.Success) Debug.Log("Installed: " + request.Result.packageId);
			else if (request.Status >= StatusCode.Failure) Debug.LogError(request.Error.message);

			if (packagesToInstall.Count > 0) {
				await Task.Delay(1000);
				StartNextPackageInstallation();
			}
		}

		public static void InstallPackage(string[] packages) {
			foreach (string package in packages) {
				packagesToInstall.Enqueue(package);
			}
			if (packagesToInstall.Count > 0) {
				StartNextPackageInstallation();
			}
		}
	}

	private static class Folders {

		public static void Delete(string folderName) {
			string pathToDelete = $"Assets/{folderName}";
			if (IsValidFolder(pathToDelete)) {
				DeleteAsset(pathToDelete);
			}
		}

		public static void Move(string newParent, string folderName) {
			string sourcePath = $"Assets/{folderName}";
			if (IsValidFolder(sourcePath)) {
				string destinationPath = $"Assets/{newParent}/{folderName}";
				string error = MoveAsset(sourcePath, destinationPath);

				if (!string.IsNullOrEmpty(error)) {
					Debug.LogError($"Failed to move {folderName}: {error}");
				}
			}
		}

		private static void CreateSubFolders(string rootpath, string folderHierarchy) {
			var folders = folderHierarchy.Split('/');
			var currentPath = rootpath;
			foreach (var folder in folders) {
				currentPath = Combine(currentPath, folder);
				if (!Directory.Exists(currentPath)) {
					Directory.CreateDirectory(currentPath);
				}
			}
		}

		public static void Create(string root, params string[] folders) {
			var fullpath = Path.Combine(Application.dataPath, root);
			if (!Directory.Exists(fullpath)) Directory.CreateDirectory(fullpath);
			foreach (var folder in folders) {
				CreateSubFolders(fullpath, folder);
			}
		}
	}
}