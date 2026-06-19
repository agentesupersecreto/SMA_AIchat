using System;
using UnityEngine;

// Token: 0x02000018 RID: 24
public class Math3dPart2
{
	// Token: 0x17000012 RID: 18
	// (get) Token: 0x060000BC RID: 188 RVA: 0x00005BB4 File Offset: 0x00003DB4
	private static Transform tempChild
	{
		get
		{
			if (Math3dPart2.m_tempChild == null)
			{
				Math3dPart2.m_tempChild = new GameObject("Math3d_TempChild").transform;
				Math3dPart2.m_tempChild.gameObject.hideFlags = HideFlags.HideAndDontSave;
				Object.DontDestroyOnLoad(Math3dPart2.m_tempChild.gameObject);
				Math3dPart2.m_tempChild.parent = Math3dPart2.tempParent;
			}
			return Math3dPart2.m_tempChild;
		}
	}

	// Token: 0x17000013 RID: 19
	// (get) Token: 0x060000BD RID: 189 RVA: 0x00005C10 File Offset: 0x00003E10
	private static Transform tempParent
	{
		get
		{
			if (Math3dPart2.m_tempParent == null)
			{
				Math3dPart2.m_tempParent = new GameObject("Math3d_TempParent").transform;
				Math3dPart2.m_tempParent.gameObject.hideFlags = HideFlags.HideAndDontSave;
				Object.DontDestroyOnLoad(Math3dPart2.m_tempParent.gameObject);
			}
			return Math3dPart2.m_tempParent;
		}
	}

	// Token: 0x060000BE RID: 190 RVA: 0x00005C5D File Offset: 0x00003E5D
	public static void Init()
	{
	}

	// Token: 0x060000BF RID: 191 RVA: 0x00005C60 File Offset: 0x00003E60
	public static void TransformWithParent(out Quaternion childRotation, out Vector3 childPosition, Quaternion parentRotation, Vector3 parentPosition, Quaternion startParentRotation, Vector3 startParentPosition, Quaternion startChildRotation, Vector3 startChildPosition)
	{
		childRotation = Quaternion.identity;
		childPosition = Vector3.zero;
		Math3dPart2.tempParent.rotation = startParentRotation;
		Math3dPart2.tempParent.position = startParentPosition;
		Math3dPart2.tempParent.localScale = Vector3.one;
		Math3dPart2.tempChild.rotation = startChildRotation;
		Math3dPart2.tempChild.position = startChildPosition;
		Math3dPart2.tempChild.localScale = Vector3.one;
		Math3dPart2.tempParent.rotation = parentRotation;
		Math3dPart2.tempParent.position = parentPosition;
		childRotation = Math3dPart2.tempChild.rotation;
		childPosition = Math3dPart2.tempChild.position;
	}

	// Token: 0x060000C0 RID: 192 RVA: 0x00005D08 File Offset: 0x00003F08
	public static bool LinearAcceleration(out Vector3 vector, Vector3 position, int samples)
	{
		Vector3 vector2 = Vector3.zero;
		vector = Vector3.zero;
		if (samples < 3)
		{
			samples = 3;
		}
		if (Math3dPart2.positionRegister == null)
		{
			Math3dPart2.positionRegister = new Vector3[samples];
			Math3dPart2.posTimeRegister = new float[samples];
		}
		for (int i = 0; i < Math3dPart2.positionRegister.Length - 1; i++)
		{
			Math3dPart2.positionRegister[i] = Math3dPart2.positionRegister[i + 1];
			Math3dPart2.posTimeRegister[i] = Math3dPart2.posTimeRegister[i + 1];
		}
		Math3dPart2.positionRegister[Math3dPart2.positionRegister.Length - 1] = position;
		Math3dPart2.posTimeRegister[Math3dPart2.posTimeRegister.Length - 1] = Time.time;
		Math3dPart2.positionSamplesTaken++;
		if (Math3dPart2.positionSamplesTaken >= samples)
		{
			for (int j = 0; j < Math3dPart2.positionRegister.Length - 2; j++)
			{
				Vector3 vector3 = Math3dPart2.positionRegister[j + 1] - Math3dPart2.positionRegister[j];
				float num = Math3dPart2.posTimeRegister[j + 1] - Math3dPart2.posTimeRegister[j];
				if (num == 0f)
				{
					return false;
				}
				Vector3 vector4 = vector3 / num;
				vector3 = Math3dPart2.positionRegister[j + 2] - Math3dPart2.positionRegister[j + 1];
				num = Math3dPart2.posTimeRegister[j + 2] - Math3dPart2.posTimeRegister[j + 1];
				if (num == 0f)
				{
					return false;
				}
				Vector3 vector5 = vector3 / num;
				vector2 += vector5 - vector4;
			}
			vector2 /= (float)(Math3dPart2.positionRegister.Length - 2);
			float num2 = Math3dPart2.posTimeRegister[Math3dPart2.posTimeRegister.Length - 1] - Math3dPart2.posTimeRegister[0];
			vector = vector2 / num2;
			return true;
		}
		return false;
	}

	// Token: 0x060000C1 RID: 193 RVA: 0x00005EC8 File Offset: 0x000040C8
	public static bool AngularAcceleration(out Vector3 vector, Quaternion rotation, int samples)
	{
		Vector3 vector2 = Vector3.zero;
		vector = Vector3.zero;
		if (samples < 3)
		{
			samples = 3;
		}
		if (Math3dPart2.rotationRegister == null)
		{
			Math3dPart2.rotationRegister = new Quaternion[samples];
			Math3dPart2.rotTimeRegister = new float[samples];
		}
		for (int i = 0; i < Math3dPart2.rotationRegister.Length - 1; i++)
		{
			Math3dPart2.rotationRegister[i] = Math3dPart2.rotationRegister[i + 1];
			Math3dPart2.rotTimeRegister[i] = Math3dPart2.rotTimeRegister[i + 1];
		}
		Math3dPart2.rotationRegister[Math3dPart2.rotationRegister.Length - 1] = rotation;
		Math3dPart2.rotTimeRegister[Math3dPart2.rotTimeRegister.Length - 1] = Time.time;
		Math3dPart2.rotationSamplesTaken++;
		if (Math3dPart2.rotationSamplesTaken >= samples)
		{
			for (int j = 0; j < Math3dPart2.rotationRegister.Length - 2; j++)
			{
				Quaternion quaternion = Math3d.SubtractRotation(Math3dPart2.rotationRegister[j + 1], Math3dPart2.rotationRegister[j]);
				float num = Math3dPart2.rotTimeRegister[j + 1] - Math3dPart2.rotTimeRegister[j];
				if (num == 0f)
				{
					return false;
				}
				Vector3 vector3 = Math3d.RotDiffToSpeedVec(quaternion, num);
				quaternion = Math3d.SubtractRotation(Math3dPart2.rotationRegister[j + 2], Math3dPart2.rotationRegister[j + 1]);
				num = Math3dPart2.rotTimeRegister[j + 2] - Math3dPart2.rotTimeRegister[j + 1];
				if (num == 0f)
				{
					return false;
				}
				Vector3 vector4 = Math3d.RotDiffToSpeedVec(quaternion, num);
				vector2 += vector4 - vector3;
			}
			vector2 /= (float)(Math3dPart2.rotationRegister.Length - 2);
			float num2 = Math3dPart2.rotTimeRegister[Math3dPart2.rotTimeRegister.Length - 1] - Math3dPart2.rotTimeRegister[0];
			vector = vector2 / num2;
			return true;
		}
		return false;
	}

	// Token: 0x04000022 RID: 34
	private static Transform m_tempChild;

	// Token: 0x04000023 RID: 35
	private static Transform m_tempParent;

	// Token: 0x04000024 RID: 36
	private static Vector3[] positionRegister;

	// Token: 0x04000025 RID: 37
	private static float[] posTimeRegister;

	// Token: 0x04000026 RID: 38
	private static int positionSamplesTaken;

	// Token: 0x04000027 RID: 39
	private static Quaternion[] rotationRegister;

	// Token: 0x04000028 RID: 40
	private static float[] rotTimeRegister;

	// Token: 0x04000029 RID: 41
	private static int rotationSamplesTaken;
}
