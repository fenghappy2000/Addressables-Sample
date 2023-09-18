

using System;
using System.Collections;
using System.Collections.Generic;

using UnityEngine;

#if UNITY_EDITOR

using UnityEditor;

using Unity.Content;
using Unity.IO.Archive;
using Unity.Jobs;

using Unity.IO.LowLevel.Unsafe;

using UnityEditor.Build.Content;

public class XABReader
{


[MenuItem("Tools/Test")]
public static void Test()
{
	string archivePath = @"d:\assets_res_level_levellayout_level_bw_countryoftime_scene.uab";

	archivePath = @"d:\assets_res_nopack_designer_levelres_commonres.uab";

	// 1.创建命名空间
	ContentNamespace ns = ContentNamespace.GetOrCreateNamespace("MyNamespace123");
	// 2.挂载文件系统
	ArchiveHandle ah = ArchiveFileInterface.MountAsync(ns, archivePath, "a:");
	ah.JobHandle.Complete();

	///////////////////////////////////////////////////////////////////////////////
	string mountPath = ah.GetMountPath();

	ArchiveStatus ars = ah.Status;
	UnityEngine.CompressionType arc = ah.Compression;
	bool isstreamed = ah.IsStreamed;

	ArchiveFileInfo[] arfs = ah.GetFileInfo();

	Debug.LogFormat("Test: arm:{0}, ars:{1}, arc:{2}, ari:{3}, arf:{4}", 
					mountPath, ars, arc, isstreamed, arfs.Length);

	AsyncReadManager.Read(
	for(int i=0;i<arfs.Length;i++) {
		ArchiveFileInfo arf = arfs[i];
		Debug.LogFormat("arf[{0}], name[{1}], size[{2}]", i, arf.Filename, arf.FileSize);
	}
	///////////////////////////////////////////////////////////////////////////////

	// 1.卸载文件系统
	JobHandle jobUnmount = ah.Unmount();
	jobUnmount.Complete();

	// 2.删除命名空间
	ns.Delete();
}


	
}


#endif // UNITY_EDITOR
