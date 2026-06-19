using System;
using System.Collections.Generic;
using Assets._ReusableScripts.CuchiCuchi.AI.Estimulos.ObjetosEstimulantes;
using Assets._ReusableScripts.CuchiCuchi.Skins;
using Assets._ReusableScripts.Globales.Updater;
using Assets._ReusableScripts.Respiracion;
using TValleCustomClases;
using UnityEngine;

namespace Assets._ReusableScripts.CuchiCuchi.Dependentes.Controllers.Interacciones.AI.Emociones
{
	// Token: 0x020001EB RID: 491
	public sealed class PuedeRespirarSegunAgarrantesEnViasRespiratorias : CustomUpdatedMonobehaviourBase, ICharacterPuedeHablar
	{
		// Token: 0x170002A5 RID: 677
		// (get) Token: 0x06000BC7 RID: 3015 RVA: 0x00038B4B File Offset: 0x00036D4B
		public override GlobalUpdater.UpdateType? updateEvent1
		{
			get
			{
				return new GlobalUpdater.UpdateType?(GlobalUpdater.UpdateType.onAI0);
			}
		}

		// Token: 0x06000BC8 RID: 3016 RVA: 0x00038B54 File Offset: 0x00036D54
		protected override void ResetUnityEvent()
		{
			base.ResetUnityEvent();
			this.m_narizBuffer.bufferTime = 2f;
			this.m_narizBuffer.bufferResetTime = 0.5f;
			this.m_bocaBuffer.bufferTime = 2f;
			this.m_bocaBuffer.bufferResetTime = 0.5f;
		}

		// Token: 0x06000BC9 RID: 3017 RVA: 0x00038BA8 File Offset: 0x00036DA8
		protected override void AwakeUnityEvent()
		{
			base.AwakeUnityEvent();
			this.m_FemaleSkins = this.GetComponentEnRoot(false);
			if (this.m_FemaleSkins == null)
			{
				throw new ArgumentNullException("m_FemaleSkins", "m_FemaleSkins null reference.");
			}
			this.m_onFoundDelegate = new EmulatedHitSkin.OnColliderFound(this.OnColliderFound);
			this.m_RespiracionEngine = this.GetComponentEnRoot(false);
			if (this.m_RespiracionEngine == null)
			{
				throw new ArgumentNullException("m_RespiracionEngine", "m_RespiracionEngine null reference.");
			}
			this.m_ICharacterGestuable = this.GetComponentEnRoot(false);
			if (this.m_ICharacterGestuable == null)
			{
				throw new ArgumentNullException("m_ICharacterGestuable", "m_ICharacterGestuable null reference.");
			}
		}

		// Token: 0x06000BCA RID: 3018 RVA: 0x00038C48 File Offset: 0x00036E48
		protected override void OnEnableUnityEvent()
		{
			base.OnEnableUnityEvent();
			this.m_puedeRespirarPorNariz = this.m_RespiracionEngine.puedeRespirarPorNarizAND.ObtenerModificadorNotNull(this);
			this.m_puedeRespirarPorBoca = this.m_RespiracionEngine.puedeRespirarPorBocaAND.ObtenerModificadorNotNull(this);
			this.m_bocaSellada = this.m_ICharacterGestuable.bocaSelladaOverrideOR.ObtenerModificadorNotNull(this);
			this.m_demandaDeOxigenoMod = this.m_RespiracionEngine.demandaDeOxigenoModificable.ObtenerModificadorNotNull(this);
		}

		// Token: 0x06000BCB RID: 3019 RVA: 0x00038CB8 File Offset: 0x00036EB8
		protected override void OnDisableUnityEvent(bool quitting)
		{
			base.OnDisableUnityEvent(quitting);
			ModificadorDeBool puedeRespirarPorNariz = this.m_puedeRespirarPorNariz;
			if (puedeRespirarPorNariz != null)
			{
				puedeRespirarPorNariz.TryRemoverDeOwner(true);
			}
			ModificadorDeBool puedeRespirarPorBoca = this.m_puedeRespirarPorBoca;
			if (puedeRespirarPorBoca != null)
			{
				puedeRespirarPorBoca.TryRemoverDeOwner(true);
			}
			ModificadorDeBool bocaSellada = this.m_bocaSellada;
			if (bocaSellada != null)
			{
				bocaSellada.TryRemoverDeOwner(true);
			}
			ModificadorDeFloat demandaDeOxigenoMod = this.m_demandaDeOxigenoMod;
			if (demandaDeOxigenoMod != null)
			{
				demandaDeOxigenoMod.TryRemoverDeOwner(true);
			}
			this.m_puedeRespirarPorNariz = null;
			this.m_puedeRespirarPorBoca = null;
			this.m_bocaSellada = null;
			this.m_demandaDeOxigenoMod = null;
		}

		// Token: 0x06000BCC RID: 3020 RVA: 0x00038D34 File Offset: 0x00036F34
		public override void OnUpdateEvent1()
		{
			if (this.m_CoolDown.isOn)
			{
				return;
			}
			this.m_demandaDeOxigenoMod.valor.valor = 1f;
			try
			{
				SingleCapsuleProxyHitSkin nariz = this.m_FemaleSkins.hitSkins.partes.nariz;
				nariz.DoCheckPublic(this.m_onFoundDelegate, this.m_agarrantesEncontrados, 3f);
				MultipleSphereProxyHitSkin labios = this.m_FemaleSkins.hitSkins.partes.labios;
				nariz.DoCheckPublic(this.m_onFoundDelegate, this.m_agarrantesEncontrados, 8f);
				this.narizBlokeadaFrame = PuedeRespirarSegunAgarrantesEnViasRespiratorias.SkinEsBlokeada(this.m_agarrantesEncontrados, nariz);
				this.bocaBlokeadaFrame = PuedeRespirarSegunAgarrantesEnViasRespiratorias.SkinEsBlokeada(this.m_agarrantesEncontrados, labios);
				bool flag = this.narizBlokeadaFrame != this.narizBlokeada;
				float num;
				if (!this.m_narizBuffer.IsBuffered(flag, out num))
				{
					this.narizBlokeada = this.narizBlokeadaFrame;
				}
				bool flag2 = this.bocaBlokeadaFrame != this.bocaBlokeada;
				float num2;
				if (!this.m_narizBuffer.IsBuffered(flag2, out num2))
				{
					this.bocaBlokeada = this.bocaBlokeadaFrame;
				}
				this.m_puedeRespirarPorNariz.valor.valor = !this.narizBlokeada;
				this.m_puedeRespirarPorBoca.valor.valor = !this.bocaBlokeada;
				this.m_bocaSellada.valor.valor = this.bocaBlokeada;
				if (this.narizBlokeada)
				{
					this.m_demandaDeOxigenoMod.valor.valor = this.m_demandaDeOxigenoMod.valor.valor * 2f;
				}
				if (this.bocaBlokeada)
				{
					this.m_demandaDeOxigenoMod.valor.valor = this.m_demandaDeOxigenoMod.valor.valor * 2f;
				}
			}
			finally
			{
				this.m_CoolDown.ApplyNext(0.25f.Random(0.5f));
				this.m_agarrantesEncontrados.Clear();
			}
		}

		// Token: 0x06000BCD RID: 3021 RVA: 0x00038F28 File Offset: 0x00037128
		private void OnColliderFound(Collider collider, object data, EmulatedHitSkin sender)
		{
			Rigidbody attachedRigidbody = collider.attachedRigidbody;
			AgarranteObjeto agarranteObjeto = ((attachedRigidbody != null) ? attachedRigidbody.GetComponent<AgarranteObjeto>() : null);
			if (agarranteObjeto != null && agarranteObjeto.agarrando)
			{
				this.m_agarrantesEncontrados.Add(agarranteObjeto);
			}
		}

		// Token: 0x06000BCE RID: 3022 RVA: 0x00038F68 File Offset: 0x00037168
		private static bool SkinEsBlokeada(IReadOnlyList<AgarranteObjeto> agarrantesEncontrados, HitSkinBasica skin)
		{
			for (int i = 0; i < agarrantesEncontrados.Count; i++)
			{
				AgarranteObjeto agarranteObjeto = agarrantesEncontrados[i];
				Vector3 vector;
				float num;
				PuedeRespirarSegunAgarrantesEnViasRespiratorias.GetCastFromAgarrante(out vector, out num, agarranteObjeto);
				if (PuedeRespirarSegunAgarrantesEnViasRespiratorias.DoOverlap(vector, num, skin))
				{
					return true;
				}
			}
			return false;
		}

		// Token: 0x06000BCF RID: 3023 RVA: 0x00038FA8 File Offset: 0x000371A8
		private static void GetCastFromAgarrante(out Vector3 point, out float radius, AgarranteObjeto agarrante)
		{
			Vector3 currentAgarrandoPosicionA = agarrante.currentAgarrandoPosicionA;
			Vector3 currentAgarrandoPosicionB = agarrante.currentAgarrandoPosicionB;
			Vector3 currentAgarrandoPosicionC = agarrante.currentAgarrandoPosicionC;
			Vector3 currentAgarrandoPosicionD = agarrante.currentAgarrandoPosicionD;
			point = (currentAgarrandoPosicionA + currentAgarrandoPosicionB + currentAgarrandoPosicionC + currentAgarrandoPosicionD) / 4f;
			radius = Mathf.Max(Vector3.Distance(point, currentAgarrandoPosicionA), Mathf.Max(Vector3.Distance(point, currentAgarrandoPosicionB), Mathf.Max(Vector3.Distance(point, currentAgarrandoPosicionC), Vector3.Distance(point, currentAgarrandoPosicionD))));
		}

		// Token: 0x06000BD0 RID: 3024 RVA: 0x00039038 File Offset: 0x00037238
		private static bool DoOverlap(Vector3 point, float radius, HitSkinBasica skin)
		{
			int num = 0;
			bool flag;
			try
			{
				LayerMask layerMask = default(LayerMask);
				for (int i = 0; i < skin.skinColliders.Count; i++)
				{
					layerMask |= 1 << skin.skinColliders[i].gameObject.layer;
				}
				num = Physics.OverlapSphereNonAlloc(point, radius, PuedeRespirarSegunAgarrantesEnViasRespiratorias.m_results, layerMask, QueryTriggerInteraction.Ignore);
				int num2 = 0;
				for (int j = 0; j < num; j++)
				{
					Collider collider = PuedeRespirarSegunAgarrantesEnViasRespiratorias.m_results[j];
					if (skin.skinCollidersSet.Contains(collider))
					{
						num2++;
					}
				}
				flag = num2 >= skin.skinColliders.Count;
			}
			finally
			{
				Array.Clear(PuedeRespirarSegunAgarrantesEnViasRespiratorias.m_results, 0, num);
			}
			return flag;
		}

		// Token: 0x06000BD1 RID: 3025 RVA: 0x00039104 File Offset: 0x00037304
		public bool PuedeIntentarHablar(out bool duracionEsIndefinida)
		{
			duracionEsIndefinida = true;
			return true;
		}

		// Token: 0x06000BD2 RID: 3026 RVA: 0x0003910A File Offset: 0x0003730A
		public bool PuedeHablarConClaridad(out bool duracionEsIndefinida)
		{
			duracionEsIndefinida = true;
			return !this.bocaBlokeada;
		}

		// Token: 0x040008A3 RID: 2211
		public bool narizBlokeadaFrame;

		// Token: 0x040008A4 RID: 2212
		public bool bocaBlokeadaFrame;

		// Token: 0x040008A5 RID: 2213
		public bool narizBlokeada;

		// Token: 0x040008A6 RID: 2214
		public bool bocaBlokeada;

		// Token: 0x040008A7 RID: 2215
		private CoolDown m_CoolDown = new CoolDown();

		// Token: 0x040008A8 RID: 2216
		private FemaleSkins m_FemaleSkins;

		// Token: 0x040008A9 RID: 2217
		private RespiracionEngine m_RespiracionEngine;

		// Token: 0x040008AA RID: 2218
		private ICharacterGestuable m_ICharacterGestuable;

		// Token: 0x040008AB RID: 2219
		[SerializeReference]
		private ModificadorDeBool m_puedeRespirarPorNariz;

		// Token: 0x040008AC RID: 2220
		[SerializeReference]
		private ModificadorDeBool m_puedeRespirarPorBoca;

		// Token: 0x040008AD RID: 2221
		[SerializeReference]
		private ModificadorDeBool m_bocaSellada;

		// Token: 0x040008AE RID: 2222
		[SerializeReference]
		private ModificadorDeFloat m_demandaDeOxigenoMod;

		// Token: 0x040008AF RID: 2223
		private EmulatedHitSkin.OnColliderFound m_onFoundDelegate;

		// Token: 0x040008B0 RID: 2224
		[SerializeField]
		private BufferedCoolDown m_narizBuffer = new BufferedCoolDown();

		// Token: 0x040008B1 RID: 2225
		[SerializeField]
		private BufferedCoolDown m_bocaBuffer = new BufferedCoolDown();

		// Token: 0x040008B2 RID: 2226
		private HashSetList<AgarranteObjeto> m_agarrantesEncontrados = new HashSetList<AgarranteObjeto>();

		// Token: 0x040008B3 RID: 2227
		private static Collider[] m_results = new Collider[100];
	}
}
