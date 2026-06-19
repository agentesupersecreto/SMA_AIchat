using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using Assets.Base.Bones.Gizmos.BeachGirl.Runtime;
using Assets.Base.Bones.Gizmos.Runtime;
using Assets._ReusableScripts.CuchiCuchi;
using Assets._ReusableScripts.Memorias;
using Assets._ReusableScripts.Memorias.JsonMemorias;
using UnityEngine;

namespace Assets.CustomPoses
{
	// Token: 0x02000023 RID: 35
	public class CustomPoseTransformData : IDisposable
	{
		// Token: 0x14000001 RID: 1
		// (add) Token: 0x060000A8 RID: 168 RVA: 0x00005238 File Offset: 0x00003438
		// (remove) Token: 0x060000A9 RID: 169 RVA: 0x00005270 File Offset: 0x00003470
		public event Action<Transform, GizmosDeSkeleton> onPoseSetToBone;

		// Token: 0x14000002 RID: 2
		// (add) Token: 0x060000AA RID: 170 RVA: 0x000052A8 File Offset: 0x000034A8
		// (remove) Token: 0x060000AB RID: 171 RVA: 0x000052E0 File Offset: 0x000034E0
		public event Action<GizmosDeSkeleton> onPoseSetToSkeleton;

		// Token: 0x060000AC RID: 172 RVA: 0x00005315 File Offset: 0x00003515
		public void Dispose()
		{
			this.nombres = null;
			this.posiciones = null;
			this.rotaciones = null;
			this.onPoseSetToBone = null;
		}

		// Token: 0x060000AD RID: 173 RVA: 0x00005334 File Offset: 0x00003534
		public void Generar(PrepararCustomPoseOnEditMode.HeelState heelState, GizmosDeSkeleton skeleton, Transform currentGoto, Vector3 animatorRootBonePositionOffset, Quaternion animatorRootBoneRotationOffset)
		{
			if (!skeleton.isAwaken)
			{
				skeleton.ManualAwake();
			}
			if (skeleton.mainBones.Count == 0)
			{
				throw new InvalidOperationException();
			}
			if (skeleton.mainBones[0] != skeleton.rootBone)
			{
				throw new NotSupportedException();
			}
			this.nombres.Clear();
			this.posiciones.Clear();
			this.rotaciones.Clear();
			this.nombres.Add(skeleton.rootBone.name);
			if (currentGoto != null)
			{
				this.posiciones.Add(currentGoto.InverseTransformPoint(skeleton.rootBone.position));
				this.rotaciones.Add(Quaternion.Inverse(currentGoto.rotation) * skeleton.rootBone.rotation);
			}
			else
			{
				this.posiciones.Add(animatorRootBonePositionOffset);
				this.rotaciones.Add(animatorRootBoneRotationOffset);
			}
			for (int i = 1; i < skeleton.mainBones.Count; i++)
			{
				Transform transform = skeleton.mainBones[i];
				this.nombres.Add(transform.name);
				this.posiciones.Add(skeleton.rootBone.InverseTransformPoint(transform.position));
				this.rotaciones.Add(Quaternion.Inverse(skeleton.rootBone.rotation) * transform.rotation);
			}
			if (this.nombres.Count != this.posiciones.Count || this.nombres.Count != this.rotaciones.Count)
			{
				throw new InvalidOperationException();
			}
		}

		// Token: 0x060000AE RID: 174 RVA: 0x000054CC File Offset: 0x000036CC
		public void Generar(MemoriaJsonGenerica memoria)
		{
			IJsonMemoryNode jsonMemoryNode = memoria.LeerDeep("root/Poses/", false);
			if (jsonMemoryNode == null)
			{
				throw new ArgumentNullException("memNode", "memNode null reference.");
			}
			IJsonMemoryNode jsonMemoryNode2 = (IJsonMemoryNode)jsonMemoryNode.FindChild("Names");
			IJsonMemoryNode jsonMemoryNode3 = (IJsonMemoryNode)jsonMemoryNode.FindChild("Positions");
			IJsonMemoryNode jsonMemoryNode4 = (IJsonMemoryNode)jsonMemoryNode.FindChild("Rotations");
			if (jsonMemoryNode2 == null)
			{
				throw new ArgumentNullException("nombresNode", "nombresNode null reference.");
			}
			if (jsonMemoryNode3 == null)
			{
				throw new ArgumentNullException("posicionesNode", "posicionesNode null reference.");
			}
			if (jsonMemoryNode4 == null)
			{
				throw new ArgumentNullException("rotacionesNode", "nombresNode null reference.");
			}
			List<ValueTuple<int, string>> list = new List<ValueTuple<int, string>>();
			List<ValueTuple<int, Vector3>> list2 = new List<ValueTuple<int, Vector3>>();
			List<ValueTuple<int, Quaternion>> list3 = new List<ValueTuple<int, Quaternion>>();
			foreach (string text in jsonMemoryNode2.data.Keys)
			{
				list.Add(new ValueTuple<int, string>(Convert.ToInt32(text, CultureInfo.InvariantCulture), jsonMemoryNode2.FindData(text)));
			}
			foreach (IMemoryNode<string, string> memoryNode in jsonMemoryNode3.children)
			{
				IJsonMemoryNode jsonMemoryNode5 = (IJsonMemoryNode)memoryNode;
				float num = jsonMemoryNode5.FindDataFloat("x", 0f);
				float num2 = jsonMemoryNode5.FindDataFloat("y", 0f);
				float num3 = jsonMemoryNode5.FindDataFloat("z", 0f);
				list2.Add(new ValueTuple<int, Vector3>(jsonMemoryNode5.GetNodeID<string, string>(), new Vector3(num, num2, num3)));
			}
			foreach (IMemoryNode<string, string> memoryNode2 in jsonMemoryNode4.children)
			{
				IJsonMemoryNode jsonMemoryNode6 = (IJsonMemoryNode)memoryNode2;
				float num4 = jsonMemoryNode6.FindDataFloat("x", 0f);
				float num5 = jsonMemoryNode6.FindDataFloat("y", 0f);
				float num6 = jsonMemoryNode6.FindDataFloat("z", 0f);
				float num7 = jsonMemoryNode6.FindDataFloat("w", 1f);
				list3.Add(new ValueTuple<int, Quaternion>(jsonMemoryNode6.GetNodeID<string, string>(), new Quaternion(num4, num5, num6, num7)));
			}
			list.Sort((ValueTuple<int, string> a, ValueTuple<int, string> b) => a.Item1.CompareTo(b.Item1));
			list2.Sort((ValueTuple<int, Vector3> a, ValueTuple<int, Vector3> b) => a.Item1.CompareTo(b.Item1));
			list3.Sort((ValueTuple<int, Quaternion> a, ValueTuple<int, Quaternion> b) => a.Item1.CompareTo(b.Item1));
			this.nombres = list.Select((ValueTuple<int, string> a) => a.Item2).ToList<string>();
			this.posiciones = list2.Select((ValueTuple<int, Vector3> a) => a.Item2).ToList<Vector3>();
			this.rotaciones = list3.Select((ValueTuple<int, Quaternion> a) => a.Item2).ToList<Quaternion>();
		}

		// Token: 0x060000AF RID: 175 RVA: 0x00005824 File Offset: 0x00003A24
		public void SetASkeleton(GizmosDeSkeleton skeleton, Transform currentGoto)
		{
			if (this.nombres[0].IndexOf("root", StringComparison.InvariantCultureIgnoreCase) < 0)
			{
				throw new InvalidOperationException("el primer nombre debe ser root");
			}
			if (this.nombres.Count != this.posiciones.Count || this.nombres.Count != this.rotaciones.Count)
			{
				throw new InvalidOperationException("toda la data debe ser del mismo tamaño");
			}
			Character componentEnRoot = skeleton.GetComponentEnRoot(false);
			if (componentEnRoot == null)
			{
				throw new ArgumentNullException("character", "character null reference.");
			}
			if (currentGoto != null)
			{
				skeleton.rootBone.position = currentGoto.TransformPoint(this.posiciones[0]);
				skeleton.rootBone.rotation = currentGoto.rotation * this.rotaciones[0];
			}
			else
			{
				skeleton.rootBone.position = componentEnRoot.animatorRootMotionTransform.TransformPoint(this.posiciones[0]);
				skeleton.rootBone.rotation = componentEnRoot.animatorRootMotionTransform.rotation * this.rotaciones[0];
			}
			for (int i = 1; i < this.nombres.Count; i++)
			{
				string text = this.nombres[i];
				Transform transform;
				if (!skeleton.mainBonesDicc.TryGetValue(text, out transform))
				{
					Debug.LogError("saved bone: " + text + " is not in custom interaction main bones", skeleton);
				}
				else
				{
					transform.SetPositionAndRotation(skeleton.rootBone.TransformPoint(this.posiciones[i]), skeleton.rootBone.rotation * this.rotaciones[i]);
					Action<Transform, GizmosDeSkeleton> action = this.onPoseSetToBone;
					if (action != null)
					{
						action(transform, skeleton);
					}
				}
			}
			Action<GizmosDeSkeleton> action2 = this.onPoseSetToSkeleton;
			if (action2 == null)
			{
				return;
			}
			action2(skeleton);
		}

		// Token: 0x04000095 RID: 149
		public List<string> nombres = new List<string>();

		// Token: 0x04000096 RID: 150
		public List<Vector3> posiciones = new List<Vector3>();

		// Token: 0x04000097 RID: 151
		public List<Quaternion> rotaciones = new List<Quaternion>();
	}
}
