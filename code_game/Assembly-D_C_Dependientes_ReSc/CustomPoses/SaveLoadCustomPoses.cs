using System;
using System.Collections.Generic;
using Assets.Base.Bones.Gizmos.BeachGirl.Runtime;
using Assets.Base.Bones.Gizmos.Runtime;
using Assets.SingletonesAndSystemasGlobales.AbstractLayer.Globales;
using Assets._ReusableScripts.CuchiCuchi;
using Assets._ReusableScripts.CuchiCuchi.Dependentes.ScenaManagers;
using Assets._ReusableScripts.Memorias;
using Assets._ReusableScripts.Memorias.JsonMemorias;
using RootMotion.Dynamics;
using RootMotion.FinalIK;
using UnityEngine;

namespace Assets.CustomPoses
{
	// Token: 0x02000025 RID: 37
	public class SaveLoadCustomPoses
	{
		// Token: 0x060000B9 RID: 185 RVA: 0x00005A7C File Offset: 0x00003C7C
		public static MemoriaJsonGenerica GenerarSaveData(Character currentChar, GizmosDeSkeleton skeletonGizmos, PrepararCustomPoseOnEditMode prepararCustomPoseOnEditMode, GoToScenaManager.GoTo currentGotoTarget, bool currentGoToIsTurnedAround, IReadOnlyList<GizmoDeBoneRMInfo> gizmosDeBonesInfo)
		{
			if (gizmosDeBonesInfo == null)
			{
				throw new ArgumentNullException("gizmosDeBonesInfo", "gizmosDeBonesInfo null reference.");
			}
			if (gizmosDeBonesInfo.Count == 0)
			{
				throw new InvalidOperationException();
			}
			if (skeletonGizmos == null)
			{
				throw new ArgumentNullException("skeletonGizmos", "skeletonGizmos null reference.");
			}
			if (currentChar == null)
			{
				throw new ArgumentNullException("currentChar", "currentChar null reference.");
			}
			MemoriaJsonGenerica memoriaJsonGenerica = new MemoriaJsonGenerica();
			IJsonMemoryNode jsonMemoryNode = memoriaJsonGenerica.EscribirDeep("root/Poses/");
			if (prepararCustomPoseOnEditMode == null)
			{
				throw new ArgumentNullException("prepararCustomPoseOnEditMode", "prepararCustomPoseOnEditMode null reference.");
			}
			Transform transform;
			if (currentGotoTarget == null)
			{
				jsonMemoryNode.AddData("GoToType", string.Empty, true);
				jsonMemoryNode.AddData("GoTo_Direction", 1f, true);
				transform = null;
			}
			else if (currentGotoTarget.esDefault)
			{
				jsonMemoryNode.AddData("GoToType", string.Empty, true);
				jsonMemoryNode.AddData("GoTo_Direction", currentGoToIsTurnedAround ? (-1f) : 1f, true);
				transform = null;
			}
			else
			{
				jsonMemoryNode.AddData("GoToType", currentGotoTarget.Type, true);
				jsonMemoryNode.AddData("GoTo_Direction", currentGoToIsTurnedAround ? (-1f) : 1f, true);
				transform = currentGotoTarget.transform;
			}
			CustomPoseTransformData customPoseTransformData = new CustomPoseTransformData();
			customPoseTransformData.Generar(prepararCustomPoseOnEditMode.heelState, skeletonGizmos, transform, -prepararCustomPoseOnEditMode.customInteractionFollower.defaultLocalOffset, Quaternion.Inverse(prepararCustomPoseOnEditMode.customInteractionFollower.defaultLocalRotOffset));
			IMemoryNode<string, string> memoryNode = jsonMemoryNode.FindChildNotNull("Names");
			IMemoryNode<string, string> memoryNode2 = jsonMemoryNode.FindChildNotNull("Positions");
			IMemoryNode<string, string> memoryNode3 = jsonMemoryNode.FindChildNotNull("Rotations");
			for (int i = 0; i < customPoseTransformData.nombres.Count; i++)
			{
				string text = i.ToString();
				memoryNode.AddData(text, customPoseTransformData.nombres[i], true);
				IJsonMemoryNode jsonMemoryNode2 = (IJsonMemoryNode)memoryNode2.FindChildNotNull(text);
				IJsonMemoryNode jsonMemoryNode3 = (IJsonMemoryNode)memoryNode3.FindChildNotNull(text);
				Vector3 vector = customPoseTransformData.posiciones[i];
				Quaternion quaternion = customPoseTransformData.rotaciones[i];
				jsonMemoryNode2.AddData("x", vector.x, true);
				jsonMemoryNode2.AddData("y", vector.y, true);
				jsonMemoryNode2.AddData("z", vector.z, true);
				jsonMemoryNode3.AddData("x", quaternion.x, true);
				jsonMemoryNode3.AddData("y", quaternion.y, true);
				jsonMemoryNode3.AddData("z", quaternion.z, true);
				jsonMemoryNode3.AddData("w", quaternion.w, true);
			}
			IMemoryNode<string, string> memoryNode4 = jsonMemoryNode.FindChildNotNull("Muscles");
			for (int j = 0; j < gizmosDeBonesInfo.Count; j++)
			{
				GizmoDeBoneRMInfo gizmoDeBoneRMInfo = gizmosDeBonesInfo[j];
				if (gizmoDeBoneRMInfo.esMusculo)
				{
					IJsonMemoryNode jsonMemoryNode4 = (IJsonMemoryNode)((IJsonMemoryNode)memoryNode4.FindChildNotNull((int)gizmoDeBoneRMInfo.muscle)).FindChildNotNull((int)gizmoDeBoneRMInfo.side);
					jsonMemoryNode4.AddData("Pin", gizmoDeBoneRMInfo.gizmoDeBone.boneMuscleConfig.musclePin, true);
					jsonMemoryNode4.AddData("Spring", gizmoDeBoneRMInfo.gizmoDeBone.boneMuscleConfig.muscleSpring, true);
					jsonMemoryNode4.AddData("Damper", gizmoDeBoneRMInfo.gizmoDeBone.boneMuscleConfig.muscleDamper, true);
				}
			}
			IMemoryNode<string, string> memoryNode5 = jsonMemoryNode.FindChildNotNull("Effectors");
			for (int k = 0; k < gizmosDeBonesInfo.Count; k++)
			{
				GizmoDeBoneRMInfo gizmoDeBoneRMInfo2 = gizmosDeBonesInfo[k];
				if (gizmoDeBoneRMInfo2.isEffector)
				{
					IJsonMemoryNode jsonMemoryNode5 = (IJsonMemoryNode)memoryNode5.FindChildNotNull((int)gizmoDeBoneRMInfo2.effector);
					jsonMemoryNode5.AddData("IsSupport", gizmoDeBoneRMInfo2.gizmoDeBone.boneMuscleConfig.puedeApoyarse, true);
					jsonMemoryNode5.AddData("CanInteract", gizmoDeBoneRMInfo2.gizmoDeBone.boneMuscleConfig.puedeInteractuar, true);
					jsonMemoryNode5.AddData("CanReact", gizmoDeBoneRMInfo2.gizmoDeBone.boneMuscleConfig.puedeReaccionar, true);
				}
			}
			return memoriaJsonGenerica;
		}

		// Token: 0x060000BA RID: 186 RVA: 0x00005E60 File Offset: 0x00004060
		public static void LoadSavedData(Character charTarget, ref string data, int customInteractionID, Action<Transform, GizmosDeSkeleton> onPoseSetToBone, Action<GizmosDeSkeleton> onPoseSetToSkeleton)
		{
			if (charTarget == null)
			{
				throw new ArgumentNullException("charTarget", "charTarget null reference.");
			}
			if (data.Length == 0)
			{
				throw new ArgumentNullException("charTarget", "charTarget null reference.");
			}
			MemoriaJsonGenerica memoriaJsonGenerica = new MemoriaJsonGenerica();
			memoriaJsonGenerica.root.Load(data);
			IJsonMemoryNode jsonMemoryNode = memoriaJsonGenerica.LeerDeep("root/Poses/", false);
			if (jsonMemoryNode == null)
			{
				throw new ArgumentNullException("memNode", "memNode null reference.");
			}
			CustomPosesDeFemaleCharacter componentEnRoot = charTarget.GetComponentEnRoot<CustomPosesDeFemaleCharacter>();
			if (componentEnRoot == null)
			{
				throw new ArgumentNullException("customInteractions", "customInteractions null reference.");
			}
			PrepararCustomPoseOnEditMode prepararCustomPoseOnEditMode;
			GizmosDeSkeleton gizmosDeSkeleton;
			componentEnRoot.Obtener(customInteractionID, out prepararCustomPoseOnEditMode, out gizmosDeSkeleton);
			if (gizmosDeSkeleton == null)
			{
				throw new ArgumentNullException("skeletonGizmos", "skeletonGizmos null reference.");
			}
			if (prepararCustomPoseOnEditMode == null)
			{
				throw new ArgumentNullException("prepararCustomPoseOnEditMode", "prepararCustomPoseOnEditMode null reference.");
			}
			GizmoDeBoneRMInfo[] componentsInChildren = gizmosDeSkeleton.GetComponentsInChildren<GizmoDeBoneRMInfo>();
			bool flag;
			GoToScenaManager.GoTo goTo = Singleton<GoToScenaManager>.instance.CurrentGoTo(charTarget.animatorRootMotionTransform, out flag, 0.4f, 45f);
			Dictionary<ValueTuple<Muscle.GroupCompleto, Side>, GizmoDeBoneRMInfo> dictionary = new Dictionary<ValueTuple<Muscle.GroupCompleto, Side>, GizmoDeBoneRMInfo>();
			Dictionary<FullBodyBipedEffector, GizmoDeBoneRMInfo> dictionary2 = new Dictionary<FullBodyBipedEffector, GizmoDeBoneRMInfo>();
			foreach (GizmoDeBoneRMInfo gizmoDeBoneRMInfo in componentsInChildren)
			{
				if (gizmoDeBoneRMInfo.esMusculo)
				{
					dictionary.Add(new ValueTuple<Muscle.GroupCompleto, Side>(gizmoDeBoneRMInfo.muscle, gizmoDeBoneRMInfo.side), gizmoDeBoneRMInfo);
				}
				if (gizmoDeBoneRMInfo.isEffector)
				{
					dictionary2.Add(gizmoDeBoneRMInfo.effector, gizmoDeBoneRMInfo);
				}
			}
			Transform transform = null;
			using (CustomPoseTransformData customPoseTransformData = new CustomPoseTransformData())
			{
				customPoseTransformData.Generar(memoriaJsonGenerica);
				if (onPoseSetToBone != null)
				{
					customPoseTransformData.onPoseSetToBone += onPoseSetToBone;
				}
				if (onPoseSetToSkeleton != null)
				{
					customPoseTransformData.onPoseSetToSkeleton += onPoseSetToSkeleton;
				}
				customPoseTransformData.SetASkeleton(gizmosDeSkeleton, transform);
			}
			jsonMemoryNode.AddData("GoToType", string.Empty, true);
			jsonMemoryNode.AddData("GoTo_Direction", 1, true);
			string text = jsonMemoryNode.FindData("GoToType");
			jsonMemoryNode.FindDataFloat("GoTo_Direction", 1f);
			if (string.IsNullOrWhiteSpace(text))
			{
				prepararCustomPoseOnEditMode.customInteractionFollower.enabled = true;
			}
			else
			{
				prepararCustomPoseOnEditMode.customInteractionFollower.enabled = false;
				prepararCustomPoseOnEditMode.transform.SetPositionAndRotation(goTo.transform.position, goTo.transform.rotation);
			}
			IMemoryNode<string, string> memoryNode = jsonMemoryNode.FindChild("Muscles");
			if (memoryNode == null)
			{
				throw new ArgumentNullException("musclesNode", "musclesNode null reference.");
			}
			foreach (IMemoryNode<string, string> memoryNode2 in memoryNode.children)
			{
				IJsonMemoryNode jsonMemoryNode2 = (IJsonMemoryNode)memoryNode2;
				foreach (IMemoryNode<string, string> memoryNode3 in jsonMemoryNode2.children)
				{
					IJsonMemoryNode jsonMemoryNode3 = (IJsonMemoryNode)memoryNode3;
					GizmoDeBoneRMInfo gizmoDeBoneRMInfo2 = dictionary[new ValueTuple<Muscle.GroupCompleto, Side>((Muscle.GroupCompleto)jsonMemoryNode2.GetNodeID<string, string>(), (Side)jsonMemoryNode3.GetNodeID<string, string>())];
					gizmoDeBoneRMInfo2.gizmoDeBone.boneMuscleConfig.musclePin = jsonMemoryNode3.FindDataFloat("Pin", 1f);
					gizmoDeBoneRMInfo2.gizmoDeBone.boneMuscleConfig.muscleSpring = jsonMemoryNode3.FindDataFloat("Spring", 1f);
					gizmoDeBoneRMInfo2.gizmoDeBone.boneMuscleConfig.muscleDamper = jsonMemoryNode3.FindDataFloat("Damper", 1f);
				}
			}
			IMemoryNode<string, string> memoryNode4 = jsonMemoryNode.FindChild("Effectors");
			if (memoryNode4 == null)
			{
				throw new ArgumentNullException("effectorNode", "effectorNode null reference.");
			}
			foreach (IMemoryNode<string, string> memoryNode5 in memoryNode4.children)
			{
				IJsonMemoryNode jsonMemoryNode4 = (IJsonMemoryNode)memoryNode5;
				GizmoDeBoneRMInfo gizmoDeBoneRMInfo3 = dictionary2[(FullBodyBipedEffector)jsonMemoryNode4.GetNodeID<string, string>()];
				gizmoDeBoneRMInfo3.gizmoDeBone.boneMuscleConfig.puedeApoyarse = jsonMemoryNode4.FindDataBool("IsSupport", false);
				gizmoDeBoneRMInfo3.gizmoDeBone.boneMuscleConfig.puedeInteractuar = jsonMemoryNode4.FindDataBool("CanInteract", true);
				gizmoDeBoneRMInfo3.gizmoDeBone.boneMuscleConfig.puedeReaccionar = jsonMemoryNode4.FindDataBool("CanReact", true);
			}
			LoadAplicarEffectorConfigDeBone[] componentsInChildren2 = gizmosDeSkeleton.GetComponentsInChildren<LoadAplicarEffectorConfigDeBone>();
			for (int j = 0; j < componentsInChildren2.Length; j++)
			{
				componentsInChildren2[j].SetConfigAEffector();
			}
			LoadAplicarMuscleConfigDeBone[] componentsInChildren3 = gizmosDeSkeleton.GetComponentsInChildren<LoadAplicarMuscleConfigDeBone>();
			for (int k = 0; k < componentsInChildren3.Length; k++)
			{
				componentsInChildren3[k].SetConfigAMuscle(false);
			}
		}
	}
}
