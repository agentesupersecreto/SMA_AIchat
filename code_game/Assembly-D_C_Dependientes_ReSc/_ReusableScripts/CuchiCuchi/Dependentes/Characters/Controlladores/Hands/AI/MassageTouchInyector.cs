using System;
using System.Collections.Generic;
using Assets.TValle.BeachGirl.Estimulos.Runtime;
using Assets._ReusableScripts.CuchiCuchi.Estimulos;
using Assets._ReusableScripts.CuchiCuchi.Interactables;
using Assets._ReusableScripts.CuchiCuchi.Skins;
using Assets._ReusableScripts.Globales.Updater;
using UnityEngine;

namespace Assets._ReusableScripts.CuchiCuchi.Dependentes.Characters.Controlladores.Hands.AI
{
	// Token: 0x0200027C RID: 636
	public class MassageTouchInyector : CustomUpdatedMonobehaviourBase
	{
		// Token: 0x1700041D RID: 1053
		// (get) Token: 0x060010BE RID: 4286 RVA: 0x00038B4B File Offset: 0x00036D4B
		public override GlobalUpdater.UpdateType? updateEvent1
		{
			get
			{
				return new GlobalUpdater.UpdateType?(GlobalUpdater.UpdateType.onAI0);
			}
		}

		// Token: 0x1700041E RID: 1054
		// (get) Token: 0x060010BF RID: 4287 RVA: 0x0004E937 File Offset: 0x0004CB37
		public override GlobalUpdater.UpdateType? updateEvent2
		{
			get
			{
				return new GlobalUpdater.UpdateType?(GlobalUpdater.UpdateType.onAI1);
			}
		}

		// Token: 0x1700041F RID: 1055
		// (get) Token: 0x060010C0 RID: 4288 RVA: 0x000066D6 File Offset: 0x000048D6
		public override int updateEvent2ExtraCalls
		{
			get
			{
				return 1;
			}
		}

		// Token: 0x060010C1 RID: 4289 RVA: 0x0004EDEC File Offset: 0x0004CFEC
		protected override void AwakeUnityEvent()
		{
			base.AwakeUnityEvent();
			this.controller = this.GetComponentEnRoot(false);
			if (this.controller == null)
			{
				throw new ArgumentNullException("controller", "controller null reference.");
			}
			this.m_PrioridadesDeObjetoEstimulado = this.GetComponentEnRoot(false);
			if (this.m_PrioridadesDeObjetoEstimulado == null)
			{
				throw new ArgumentNullException("m_PrioridadesDeObjetoEstimulado", "m_PrioridadesDeObjetoEstimulado null reference.");
			}
		}

		// Token: 0x060010C2 RID: 4290 RVA: 0x0004EE4F File Offset: 0x0004D04F
		protected override void OnEnableUnityEvent()
		{
			base.OnEnableUnityEvent();
			this.controller.onMassageUpdate += this.Controller_onMassageUpdate;
		}

		// Token: 0x060010C3 RID: 4291 RVA: 0x0004EE6E File Offset: 0x0004D06E
		protected override void OnDisableUnityEvent(bool quitting)
		{
			base.OnDisableUnityEvent(quitting);
			if (this.controller != null)
			{
				this.controller.onMassageUpdate -= this.Controller_onMassageUpdate;
			}
			this.RetornarTodoAPool();
			this.m_pedidos.Clear();
		}

		// Token: 0x060010C4 RID: 4292 RVA: 0x0004EEB0 File Offset: 0x0004D0B0
		private void Controller_onMassageUpdate(Vector3 velocidadPhyscis, Vector3 recorridoPosition, Quaternion recoridoRotation, float recorridoVelocidad, float recorridoWeigth, bool comenzando, bool terminando, bool terminada, ICharacter por, HitSkin porHand, ICharacter to, MaleHitSkinBasica toMaleParte, RecorridoDeMassgeOnMaleBody.Recorrido recorrido)
		{
			if (comenzando || terminando || terminada || toMaleParte == null || recorrido == RecorridoDeMassgeOnMaleBody.Recorrido.None)
			{
				return;
			}
			this.m_pedidos.Add(new MassageTouchInyector.Pedido
			{
				velocidadPhyscis = velocidadPhyscis,
				recorridoPosition = recorridoPosition,
				recoridoRotation = recoridoRotation,
				por = por,
				porHand = porHand,
				to = to,
				recorrido = recorrido,
				toBodySkin = toMaleParte
			});
		}

		// Token: 0x060010C5 RID: 4293 RVA: 0x0004EF2F File Offset: 0x0004D12F
		public override void OnUpdateEvent1()
		{
			this.RetornarTodoAPool();
		}

		// Token: 0x060010C6 RID: 4294 RVA: 0x0004EF38 File Offset: 0x0004D138
		private void RetornarTodoAPool()
		{
			for (int i = 0; i < this.m_usados.Count; i++)
			{
				this.m_poolDeEstimulos.ReturnItem(this.m_usados[i]);
			}
			this.m_usados.Clear();
		}

		// Token: 0x060010C7 RID: 4295 RVA: 0x0004EF80 File Offset: 0x0004D180
		public override void OnUpdateEvent2()
		{
			if (GlobalUpdater.CurrentUserCallCount(base.updaterUser) != 2)
			{
				return;
			}
			for (int i = this.m_pedidos.Count - 1; i >= 0; i--)
			{
				MassageTouchInyector.Pedido pedido = this.m_pedidos[i];
				MaleHitSkinBasica toBodySkin = pedido.toBodySkin;
				TocanteObjeto component = toBodySkin.GetComponent<TocanteObjeto>();
				TocanteObjeto component2 = pedido.porHand.GetComponent<TocanteObjeto>();
				HitSkin.TouchedBy<TocanteObjeto>.SkinTouchStats item = this.m_poolDeEstimulos.GetItem();
				HitSkin.TouchedBy<TocanteObjeto>.SkinTouchStats item2 = this.m_poolDeEstimulos.GetItem();
				item2.DefinirReferencias(component, this.m_PrioridadesDeObjetoEstimulado, component2, pedido.porHand.boneTarget, null);
				item2.DefinirTransformsYVectores(toBodySkin.rigid.transform, new Vector3?(pedido.recoridoRotation * Vector3.up), new Vector3?(pedido.recorridoPosition), null);
				item.DefinirReferencias(component2, this.m_PrioridadesDeObjetoEstimulado, component, toBodySkin.rigid.transform, null);
				item.DefinirTransformsYVectores(pedido.porHand.boneTarget, new Vector3?(pedido.recoridoRotation * Vector3.up), new Vector3?(pedido.recorridoPosition), null);
				item.side = (item2.side = Side.none);
				ParteDelCuerpoHumano parteDelCuerpoHumano;
				switch (pedido.recorrido)
				{
				case RecorridoDeMassgeOnMaleBody.Recorrido.Chest:
					parteDelCuerpoHumano = ParteDelCuerpoHumano.pecho;
					break;
				case RecorridoDeMassgeOnMaleBody.Recorrido.Nipple:
					parteDelCuerpoHumano = ParteDelCuerpoHumano.pezones;
					break;
				case RecorridoDeMassgeOnMaleBody.Recorrido.Shoulder:
					parteDelCuerpoHumano = ParteDelCuerpoHumano.hombros;
					break;
				case RecorridoDeMassgeOnMaleBody.Recorrido.Abdomen:
					parteDelCuerpoHumano = ParteDelCuerpoHumano.abdomen;
					break;
				case RecorridoDeMassgeOnMaleBody.Recorrido.Groin:
					parteDelCuerpoHumano = ParteDelCuerpoHumano.vientreBajo;
					break;
				case RecorridoDeMassgeOnMaleBody.Recorrido.Leg:
					parteDelCuerpoHumano = ParteDelCuerpoHumano.piernas;
					break;
				case RecorridoDeMassgeOnMaleBody.Recorrido.Calf:
					parteDelCuerpoHumano = ParteDelCuerpoHumano.canillas;
					break;
				default:
					throw new ArgumentOutOfRangeException(pedido.recorrido.ToString());
				}
				item2.AddParteEstimulada(parteDelCuerpoHumano);
				item.AddParteEstimulada(ParteDelCuerpoHumano.manos);
				item.tipoDeEstimulo = (item2.tipoDeEstimulo = TipoDeEstimulo.tactil);
				item2.tipo = DireccionDeEstimulo.dada;
				item.tipo = DireccionDeEstimulo.recibida;
				item2.SetTipoDeEstimuloTactil(TipoDeEstimuloTactil.caricia);
				item.SetTipoDeEstimuloTactil(TipoDeEstimuloTactil.caricia);
				item2.SetTipoDeEstimuloTactil(TipoDeEstimuloTactilInvertido.massage);
				item.SetTipoDeEstimuloTactil(TipoDeEstimuloTactilInvertido.None);
				item.velocidadRelativaEmuladaMaxima = (item2.velocidadRelativaEmuladaMaxima = pedido.velocidadPhyscis.magnitude);
				item.velocidadRelativaEmuladaTotal = (item2.velocidadRelativaEmuladaTotal = item2.velocidadRelativaEmuladaMaxima);
				item.velocidadEstimuladoEmulada = (item2.velocidadEstimuladoEmulada = pedido.velocidadPhyscis);
				item.velocidadEstimulanteEmulada = (item2.velocidadEstimulanteEmulada = pedido.velocidadPhyscis);
				item.velocidadRelativaEmulada = (item2.velocidadRelativaEmulada = pedido.velocidadPhyscis);
				item.velocidadRelativaPhysics = (item2.velocidadRelativaPhysics = pedido.velocidadPhyscis);
				item.velocidadRelativaPhysicsMagnitud = (item2.velocidadRelativaPhysicsMagnitud = pedido.velocidadPhyscis.magnitude);
				item.impulsoPhysics = (item2.impulsoPhysics = pedido.velocidadPhyscis);
				item.esDePhysicsEngine = (item2.esDePhysicsEngine = false);
				item.cantidadDeContanctos = (item2.cantidadDeContanctos = 1);
				pedido.porHand.touchedByCharacteres.TryInyectar<HitSkin.TouchedBy<TocanteObjeto>.SkinTouchStats>(pedido.to, component2, item2);
				pedido.porHand.touchedByCharacteres.TryInyectar<HitSkin.TouchedBy<TocanteObjeto>.SkinTouchStats>(pedido.to, component, item);
				((IInteracionEstimulanteInversible)item2).SetAsInvertedCopy(item);
				this.m_usados.Add(item2);
				this.m_usados.Add(item);
				this.m_pedidos.RemoveAt(i);
			}
		}

		// Token: 0x04000C3B RID: 3131
		private MassageController controller;

		// Token: 0x04000C3C RID: 3132
		[SerializeField]
		private List<MassageTouchInyector.Pedido> m_pedidos = new List<MassageTouchInyector.Pedido>();

		// Token: 0x04000C3D RID: 3133
		[SerializeField]
		private List<HitSkin.TouchedBy<TocanteObjeto>.SkinTouchStats> m_usados = new List<HitSkin.TouchedBy<TocanteObjeto>.SkinTouchStats>();

		// Token: 0x04000C3E RID: 3134
		private PoolDeInteraccionEstimulante<HitSkin.TouchedBy<TocanteObjeto>.SkinTouchStats> m_poolDeEstimulos = new PoolDeInteraccionEstimulante<HitSkin.TouchedBy<TocanteObjeto>.SkinTouchStats>();

		// Token: 0x04000C3F RID: 3135
		private IParteDelCuerpoHumanoPrioridades m_PrioridadesDeObjetoEstimulado;

		// Token: 0x0200027D RID: 637
		[Serializable]
		public struct Pedido
		{
			// Token: 0x04000C40 RID: 3136
			public Vector3 velocidadPhyscis;

			// Token: 0x04000C41 RID: 3137
			public Vector3 recorridoPosition;

			// Token: 0x04000C42 RID: 3138
			public Quaternion recoridoRotation;

			// Token: 0x04000C43 RID: 3139
			public ICharacter por;

			// Token: 0x04000C44 RID: 3140
			public HitSkin porHand;

			// Token: 0x04000C45 RID: 3141
			public ICharacter to;

			// Token: 0x04000C46 RID: 3142
			public RecorridoDeMassgeOnMaleBody.Recorrido recorrido;

			// Token: 0x04000C47 RID: 3143
			public MaleHitSkinBasica toBodySkin;
		}
	}
}
