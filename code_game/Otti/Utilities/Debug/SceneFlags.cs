using System;
using System.Collections.Generic;
using UnityEngine;

namespace com.ootii.Utilities.Debug
{
	// Token: 0x0200001C RID: 28
	public class SceneFlags : MonoBehaviour
	{
		// Token: 0x06000189 RID: 393 RVA: 0x0000A20F File Offset: 0x0000840F
		public static void AddFlag(Vector3 rPosition, Quaternion rRotation)
		{
			SceneFlags.AddFlag(rPosition, rRotation, 1f, Color.black, "", Vector3.zero);
		}

		// Token: 0x0600018A RID: 394 RVA: 0x0000A22C File Offset: 0x0000842C
		public static void AddFlag(Vector3 rPosition, Quaternion rRotation, Color rColor)
		{
			SceneFlags.AddFlag(rPosition, rRotation, 1f, rColor, "", Vector3.zero);
		}

		// Token: 0x0600018B RID: 395 RVA: 0x0000A245 File Offset: 0x00008445
		public static void AddFlag(Vector3 rPosition, Quaternion rRotation, float rHeight, Color rColor)
		{
			SceneFlags.AddFlag(rPosition, rRotation, rHeight, rColor, "", Vector3.zero);
		}

		// Token: 0x0600018C RID: 396 RVA: 0x0000A25A File Offset: 0x0000845A
		public static void AddFlag(Vector3 rPosition, Quaternion rRotation, Color rColor, string rText)
		{
			SceneFlags.AddFlag(rPosition, rRotation, 1f, rColor, rText, Vector3.zero);
		}

		// Token: 0x0600018D RID: 397 RVA: 0x0000A26F File Offset: 0x0000846F
		public static void AddFlag(Vector3 rPosition, Quaternion rRotation, float rHeight, Color rColor, string rText)
		{
			SceneFlags.AddFlag(rPosition, rRotation, rHeight, rColor, rText, Vector3.zero);
		}

		// Token: 0x0600018E RID: 398 RVA: 0x0000A281 File Offset: 0x00008481
		public static void AddFlag(Vector3 rPosition, Quaternion rRotation, Color rColor, Vector3 rVector)
		{
			SceneFlags.AddFlag(rPosition, rRotation, 1f, rColor, "", rVector);
		}

		// Token: 0x0600018F RID: 399 RVA: 0x0000A298 File Offset: 0x00008498
		public static void AddFlag(Vector3 rPosition, Quaternion rRotation, float rHeight, Color rColor, string rText, Vector3 rVector)
		{
			if (!SceneFlags.IsActive)
			{
				return;
			}
			SceneFlags.SceneFlag sceneFlag = default(SceneFlags.SceneFlag);
			sceneFlag.Position = rPosition;
			sceneFlag.Rotation = rRotation;
			sceneFlag.Height = rHeight;
			sceneFlag.Color = rColor;
			sceneFlag.Text = rText;
			sceneFlag.Vector = rVector;
			SceneFlags.Flags.Add(sceneFlag);
		}

		// Token: 0x17000051 RID: 81
		// (get) Token: 0x06000190 RID: 400 RVA: 0x0000A2F2 File Offset: 0x000084F2
		// (set) Token: 0x06000191 RID: 401 RVA: 0x0000A2FA File Offset: 0x000084FA
		public bool IsEnabled
		{
			get
			{
				return this._IsEnabled;
			}
			set
			{
				this._IsEnabled = value;
				SceneFlags.IsActive = this._IsEnabled;
			}
		}

		// Token: 0x06000192 RID: 402 RVA: 0x0000A30E File Offset: 0x0000850E
		private void Awake()
		{
			SceneFlags.IsActive = this._IsEnabled;
			SceneFlags.Flags.Clear();
		}

		// Token: 0x06000193 RID: 403 RVA: 0x0000A325 File Offset: 0x00008525
		private void OnDrawGizmos()
		{
		}

		// Token: 0x040000F7 RID: 247
		public static bool IsActive = true;

		// Token: 0x040000F8 RID: 248
		public static List<SceneFlags.SceneFlag> Flags = new List<SceneFlags.SceneFlag>();

		// Token: 0x040000F9 RID: 249
		public bool _IsEnabled = true;

		// Token: 0x0200012B RID: 299
		public struct SceneFlag
		{
			// Token: 0x04000DBD RID: 3517
			public Vector3 Position;

			// Token: 0x04000DBE RID: 3518
			public Quaternion Rotation;

			// Token: 0x04000DBF RID: 3519
			public float Height;

			// Token: 0x04000DC0 RID: 3520
			public Color Color;

			// Token: 0x04000DC1 RID: 3521
			public string Text;

			// Token: 0x04000DC2 RID: 3522
			public Vector3 Vector;
		}
	}
}
