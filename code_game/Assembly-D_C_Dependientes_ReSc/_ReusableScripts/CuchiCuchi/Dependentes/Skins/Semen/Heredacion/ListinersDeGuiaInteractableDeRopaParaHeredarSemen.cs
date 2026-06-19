using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Assets.TValle.BeachGirl.Runtime.Skins.Physics;
using Assets._ReusableScripts.CuchiCuchi.AI.Ropa;
using Assets._ReusableScripts.CuchiCuchi.Characters.Skins.Semen;
using Assets._ReusableScripts.CuchiCuchi.Ropa;
using Assets._ReusableScripts.CuchiCuchi.Skins;
using Assets._ReusableScripts.CuchiCuchi.Skins.Semen;
using Assets._ReusableScripts.Globales.Updater;
using UnityEngine;

namespace Assets._ReusableScripts.CuchiCuchi.Dependentes.Skins.Semen.Heredacion
{
	// Token: 0x0200007A RID: 122
	public class ListinersDeGuiaInteractableDeRopaParaHeredarSemen : CustomMonobehaviour
	{
		// Token: 0x0600029F RID: 671 RVA: 0x000124D4 File Offset: 0x000106D4
		protected override void AwakeUnityEvent()
		{
			base.AwakeUnityEvent();
			this.m_GuiaDeRopaInteractable = base.GetComponent<GuiaDeRopaInteractable>();
			if (this.m_GuiaDeRopaInteractable == null)
			{
				throw new ArgumentNullException("m_GuiaDeRopaInteractable", "m_GuiaDeRopaInteractable null reference.");
			}
		}

		// Token: 0x060002A0 RID: 672 RVA: 0x00012506 File Offset: 0x00010706
		protected override void OnEnableUnityEvent()
		{
			base.OnEnableUnityEvent();
			this.m_GuiaDeRopaInteractable.piezaChangingWaitFor += this.M_GuiaDeRopaInteractable_piezaChangingWaitFor;
			this.m_GuiaDeRopaInteractable.piezaChanging += this.M_GuiaDeRopaInteractable_piezaChanging;
		}

		// Token: 0x060002A1 RID: 673 RVA: 0x0001253C File Offset: 0x0001073C
		protected override void OnDisableUnityEvent(bool quitting)
		{
			base.OnDisableUnityEvent(quitting);
			if (this.m_GuiaDeRopaInteractable != null)
			{
				this.m_GuiaDeRopaInteractable.piezaChangingWaitFor -= this.M_GuiaDeRopaInteractable_piezaChangingWaitFor;
				this.m_GuiaDeRopaInteractable.piezaChanging -= this.M_GuiaDeRopaInteractable_piezaChanging;
			}
		}

		// Token: 0x060002A2 RID: 674 RVA: 0x0001258C File Offset: 0x0001078C
		private void M_GuiaDeRopaInteractable_piezaChangingWaitFor(PiezaDeRopaBase siendoRemovida, ModificableDeBool Or, GuiaDeRopaInteractable sender)
		{
			if (this.m_HeredarData != null && !this.m_HeredarData.finalizado)
			{
				return;
			}
			SemenSkinController semenSkinController = ((siendoRemovida != null) ? siendoRemovida.GetComponent<SemenSkinController>() : null);
			if (semenSkinController == null || semenSkinController.semenSkins == null || semenSkinController.semenSkins.Count == 0)
			{
				return;
			}
			List<ValueTuple<SemenSelfPointToSemenSkinData, SemenPointToSemenSkinData>> list = new List<ValueTuple<SemenSelfPointToSemenSkinData, SemenPointToSemenSkinData>>();
			for (int i = 0; i < semenSkinController.semenSkins.Count; i++)
			{
				SemenSkinController.SemenSkin semenSkin = semenSkinController.semenSkins[i];
				if (semenSkin != null)
				{
					semenSkin.GetParticlesData(list);
				}
			}
			if (list.Count == 0)
			{
				return;
			}
			ModificadorDeBool modificadorDeBool = Or.ObtenerModificadorNotNull(this);
			modificadorDeBool.valor.valor = true;
			this.m_HeredarData = new ListinersDeGuiaInteractableDeRopaParaHeredarSemen.HeredarData();
			this.m_HeredarData.sender = sender;
			this.m_HeredarData.siendoRemovida = siendoRemovida;
			this.m_HeredarData.removingSkinHandler = new ListinersDeGuiaInteractableDeRopaParaHeredarSemen.RemovingSkinHandler(this, this.m_HeredarData);
			this.m_HeredarData.particleData = list;
			siendoRemovida.Cook(this.m_HeredarData.removingSkinHandler, false, modificadorDeBool);
		}

		// Token: 0x060002A3 RID: 675 RVA: 0x00012688 File Offset: 0x00010888
		private void M_GuiaDeRopaInteractable_piezaChanging(PiezaDeRopaBase siendoRemovida, PiezaDeRopaBase siendoAdded, GuiaDeRopaInteractable sender)
		{
			if (this.m_Coroutine != null && !this.m_Coroutine.finalizada)
			{
				return;
			}
			if (this.m_HeredarData == null)
			{
				return;
			}
			this.m_HeredarData.siendoAdded = siendoAdded;
			this.m_HeredarData.addingSkinHandler = new ListinersDeGuiaInteractableDeRopaParaHeredarSemen.AddingSkinHandler(this, this.m_HeredarData);
			this.m_Coroutine = GlobalUpdater.instancia.StartCorrutinaOnEvent<ListinersDeGuiaInteractableDeRopaParaHeredarSemen.HeredarData>(GlobalUpdater.UpdateType.yieldFixedOnUpdateEmulacionDeEventosDeColision, this.m_HeredarData, this, this.HeredarRutine(this.m_HeredarData), new GlobalUpdater.Corrutina<ListinersDeGuiaInteractableDeRopaParaHeredarSemen.HeredarData>.OnEndedHandlerConEstado(this.OnEndedHandlerConEstado));
		}

		// Token: 0x060002A4 RID: 676 RVA: 0x00012708 File Offset: 0x00010908
		private void OnEndedHandlerConEstado(ListinersDeGuiaInteractableDeRopaParaHeredarSemen.HeredarData heredarData, MonoBehaviour owner, ManualCorrutina ended, Exception error)
		{
			heredarData.Clear(heredarData.failed || error != null);
			heredarData.finalizado = true;
		}

		// Token: 0x060002A5 RID: 677 RVA: 0x00012727 File Offset: 0x00010927
		private IEnumerator HeredarRutine(ListinersDeGuiaInteractableDeRopaParaHeredarSemen.HeredarData heredarData)
		{
			while (!heredarData.siendoAdded.isStared)
			{
				yield return null;
			}
			if (heredarData.siendoAdded == null || !heredarData.siendoAdded.CheckIfIsTriangleAttachable())
			{
				heredarData.failed = true;
				yield break;
			}
			yield return heredarData.siendoAdded.InitTriangleAttachmentSystem();
			heredarData.siendoAdded.Cook(heredarData.addingSkinHandler, false, null);
			while (!heredarData.cooked)
			{
				yield return null;
			}
			SemenSkinController semenSkinController;
			if (heredarData == null)
			{
				semenSkinController = null;
			}
			else
			{
				PiezaDeRopaBase siendoAdded = heredarData.siendoAdded;
				semenSkinController = ((siendoAdded != null) ? siendoAdded.GetComponentNotNull<SemenSkinController>() : null);
			}
			SemenSkinController semenSkinController2 = semenSkinController;
			if (((heredarData != null) ? heredarData.particleData : null) != null)
			{
				for (int i = 0; i < heredarData.particleData.Count; i++)
				{
					ValueTuple<SemenSelfPointToSemenSkinData, SemenPointToSemenSkinData> valueTuple = heredarData.particleData[i];
					semenSkinController2.Add(ref valueTuple.Item1, ref valueTuple.Item2);
				}
			}
			semenSkinController2.flagDontWait = true;
			yield break;
		}

		// Token: 0x040002CA RID: 714
		private GuiaDeRopaInteractable m_GuiaDeRopaInteractable;

		// Token: 0x040002CB RID: 715
		private GlobalUpdater.Corrutina m_Coroutine;

		// Token: 0x040002CC RID: 716
		private ListinersDeGuiaInteractableDeRopaParaHeredarSemen.HeredarData m_HeredarData;

		// Token: 0x0200007B RID: 123
		private class HeredarData
		{
			// Token: 0x060002A7 RID: 679 RVA: 0x00012738 File Offset: 0x00010938
			public void Clear(bool clearImpactadas)
			{
				if (clearImpactadas)
				{
					for (int i = 0; i < this.particleData.Count; i++)
					{
						ValueTuple<SemenSelfPointToSemenSkinData, SemenPointToSemenSkinData> valueTuple = this.particleData[i];
						if (valueTuple.Item1.partesImpactadas.IsCreated)
						{
							valueTuple.Item1.partesImpactadas.Dispose();
						}
					}
				}
				this.particleData = null;
				this.sender = null;
				this.siendoRemovida = null;
				this.removingSkinHandler = null;
				this.addingSkinHandler = null;
				this.siendoAdded = null;
			}

			// Token: 0x040002CD RID: 717
			public GuiaDeRopaInteractable sender;

			// Token: 0x040002CE RID: 718
			public PiezaDeRopaBase siendoRemovida;

			// Token: 0x040002CF RID: 719
			public ListinersDeGuiaInteractableDeRopaParaHeredarSemen.RemovingSkinHandler removingSkinHandler;

			// Token: 0x040002D0 RID: 720
			[TupleElementNames(new string[] { "selfData", "nextData" })]
			public List<ValueTuple<SemenSelfPointToSemenSkinData, SemenPointToSemenSkinData>> particleData;

			// Token: 0x040002D1 RID: 721
			public ListinersDeGuiaInteractableDeRopaParaHeredarSemen.AddingSkinHandler addingSkinHandler;

			// Token: 0x040002D2 RID: 722
			public PiezaDeRopaBase siendoAdded;

			// Token: 0x040002D3 RID: 723
			public bool cooked;

			// Token: 0x040002D4 RID: 724
			public bool finalizado;

			// Token: 0x040002D5 RID: 725
			public bool failed;
		}

		// Token: 0x0200007C RID: 124
		private class RemovingSkinHandler : PedidoDePhyscisBakeDeSkin.IUser
		{
			// Token: 0x060002A9 RID: 681 RVA: 0x000127B9 File Offset: 0x000109B9
			public RemovingSkinHandler(ListinersDeGuiaInteractableDeRopaParaHeredarSemen Owner, ListinersDeGuiaInteractableDeRopaParaHeredarSemen.HeredarData Data)
			{
				this.m_data = Data;
				this.m_owner = Owner;
			}

			// Token: 0x060002AA RID: 682 RVA: 0x000127D0 File Offset: 0x000109D0
			void PedidoDePhyscisBakeDeSkin.IUser.OnCooked(Mesh mesh, MeshCollider collider, object extraData, Skin cooked, PedidoDePhyscisBakeDeSkin sender)
			{
				ModificadorDeBool modificadorDeBool = extraData as ModificadorDeBool;
				modificadorDeBool.valor.valor = false;
				modificadorDeBool.TryRemoverDeOwner(this.m_owner);
				for (int i = 0; i < this.m_data.particleData.Count; i++)
				{
					ValueTuple<SemenSelfPointToSemenSkinData, SemenPointToSemenSkinData> valueTuple = this.m_data.particleData[i];
					int num;
					int num2;
					int num3;
					Vector3 vector;
					Vector3 vector2;
					Vector3 vector3;
					Vector3 vector4;
					Vector3 vector5;
					Vector3 vector6;
					Vector3 vector7;
					Vector3 vector8;
					Vector3 vector9;
					Vector3 vector10;
					Vector3 vector11;
					Vector3 vector12;
					Vector3 vector13;
					Vector3 vector14;
					Vector3 vector15;
					Vector3 vector16;
					Vector3 vector17;
					Vector3 vector18;
					sender.GetWorldVerticesOfTriangle(valueTuple.Item1.semenData.hitData.triangleIndex, out num, out num2, out num3, out vector, out vector2, out vector3, out vector4, out vector5, out vector6, out vector7, out vector8, out vector9, out vector10, out vector11, out vector12, out vector13, out vector14, out vector15, out vector16, out vector17, out vector18);
					Vector3 barycentricCoordinate = valueTuple.Item1.semenData.hitData.barycentricCoordinate;
					Vector3 vector19 = vector13 * barycentricCoordinate.x + vector14 * barycentricCoordinate.y + vector15 * barycentricCoordinate.z;
					Vector3 vector20 = vector10 * barycentricCoordinate.x + vector11 * barycentricCoordinate.y + vector12 * barycentricCoordinate.z;
					valueTuple.Item1.semenData.hitData.wNormal = vector19;
					valueTuple.Item1.semenData.hitData.wPoint = vector20;
					int num4;
					int num5;
					int num6;
					Vector3 vector21;
					Vector3 vector22;
					Vector3 vector23;
					Vector3 vector24;
					Vector3 vector25;
					Vector3 vector26;
					Vector3 vector27;
					Vector3 vector28;
					Vector3 vector29;
					Vector3 vector30;
					Vector3 vector31;
					Vector3 vector32;
					Vector3 vector33;
					Vector3 vector34;
					Vector3 vector35;
					Vector3 vector36;
					Vector3 vector37;
					Vector3 vector38;
					sender.GetWorldVerticesOfTriangle(valueTuple.Item2.hitData.triangleIndex, out num4, out num5, out num6, out vector21, out vector22, out vector23, out vector24, out vector25, out vector26, out vector27, out vector28, out vector29, out vector30, out vector31, out vector32, out vector33, out vector34, out vector35, out vector36, out vector37, out vector38);
					Vector3 barycentricCoordinate2 = valueTuple.Item2.hitData.barycentricCoordinate;
					Vector3 vector39 = vector33 * barycentricCoordinate2.x + vector34 * barycentricCoordinate2.y + vector35 * barycentricCoordinate2.z;
					Vector3 vector40 = vector30 * barycentricCoordinate2.x + vector31 * barycentricCoordinate2.y + vector32 * barycentricCoordinate2.z;
					valueTuple.Item2.hitData.wNormal = vector39;
					valueTuple.Item2.hitData.wPoint = vector40;
					this.m_data.particleData[i] = valueTuple;
				}
			}

			// Token: 0x040002D6 RID: 726
			private readonly ListinersDeGuiaInteractableDeRopaParaHeredarSemen m_owner;

			// Token: 0x040002D7 RID: 727
			private readonly ListinersDeGuiaInteractableDeRopaParaHeredarSemen.HeredarData m_data;
		}

		// Token: 0x0200007D RID: 125
		private class AddingSkinHandler : PedidoDePhyscisBakeDeSkin.IUser
		{
			// Token: 0x060002AB RID: 683 RVA: 0x00012A23 File Offset: 0x00010C23
			public AddingSkinHandler(ListinersDeGuiaInteractableDeRopaParaHeredarSemen Owner, ListinersDeGuiaInteractableDeRopaParaHeredarSemen.HeredarData Data)
			{
				this.m_data = Data;
				this.m_owner = Owner;
			}

			// Token: 0x060002AC RID: 684 RVA: 0x00012A3C File Offset: 0x00010C3C
			void PedidoDePhyscisBakeDeSkin.IUser.OnCooked(Mesh mesh, MeshCollider collider, object extraData, Skin cooked, PedidoDePhyscisBakeDeSkin sender)
			{
				if (this.m_data == null)
				{
					return;
				}
				for (int i = this.m_data.particleData.Count - 1; i >= 0; i--)
				{
					ValueTuple<SemenSelfPointToSemenSkinData, SemenPointToSemenSkinData> valueTuple = this.m_data.particleData[i];
					SemenPuntoCollisionContraSkin.SkinHitResult result = SemenPuntoCollisionContraSkin.SkinHitResult.GetResult(sender.owner.skinnedMeshRenderer.transform.rotation * valueTuple.Item1.semenData.hitData.initialLocalRotationFromMesh, sender, collider, -valueTuple.Item1.semenData.hitData.wNormal, valueTuple.Item1.semenData.hitData.wPoint, valueTuple.Item1.semenData.hitData.prioridad, valueTuple.Item1.semenData.hitData.semenColliderOffset, 1f, 0f);
					valueTuple.Item1.semenData.hitData = result.data;
					if (!result.data.usable)
					{
						valueTuple.Item1.semenData.existio = false;
						valueTuple.Item2.existio = false;
						if (valueTuple.Item1.partesImpactadas.IsCreated)
						{
							valueTuple.Item1.partesImpactadas.Dispose();
						}
						this.m_data.particleData.RemoveAt(i);
					}
					else
					{
						if (valueTuple.Item2.existio)
						{
							SemenPuntoCollisionContraSkin.SkinHitResult result2 = SemenPuntoCollisionContraSkin.SkinHitResult.GetResult(sender.owner.skinnedMeshRenderer.transform.rotation * valueTuple.Item2.hitData.initialLocalRotationFromMesh, sender, collider, -valueTuple.Item2.hitData.wNormal, valueTuple.Item2.hitData.wPoint, valueTuple.Item2.hitData.prioridad, valueTuple.Item2.hitData.semenColliderOffset, 1f, 0f);
							valueTuple.Item2.hitData = result2.data;
							if (!result2.data.usable)
							{
								valueTuple.Item2.existio = false;
							}
						}
						this.m_data.particleData[i] = valueTuple;
					}
				}
				this.m_data.cooked = true;
			}

			// Token: 0x040002D8 RID: 728
			private readonly ListinersDeGuiaInteractableDeRopaParaHeredarSemen m_owner;

			// Token: 0x040002D9 RID: 729
			private readonly ListinersDeGuiaInteractableDeRopaParaHeredarSemen.HeredarData m_data;
		}
	}
}
