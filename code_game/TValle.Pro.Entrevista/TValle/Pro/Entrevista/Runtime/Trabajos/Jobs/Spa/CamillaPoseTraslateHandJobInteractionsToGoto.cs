using System;
using System.Collections;
using System.Linq;
using Assets.SingletonesAndSystemasGlobales.AbstractLayer.Globales;
using Assets._ReusableScripts.CuchiCuchi.Dependentes.Controllers.Interacciones;
using Assets._ReusableScripts.CuchiCuchi.Dependentes.ScenaManagers;
using Assets._ReusableScripts.Globales.Updater;
using UnityEngine;

namespace Assets.TValle.Pro.Entrevista.Runtime.Trabajos.Jobs.Spa
{
	// Token: 0x02000070 RID: 112
	[RequireComponent(typeof(Interaccion))]
	public class CamillaPoseTraslateHandJobInteractionsToGoto : CustomMonobehaviour
	{
		// Token: 0x060004D9 RID: 1241 RVA: 0x0001C674 File Offset: 0x0001A874
		protected override void AwakeUnityEvent()
		{
			base.AwakeUnityEvent();
			this.m_Interaccion = base.GetComponent<Interaccion>();
		}

		// Token: 0x060004DA RID: 1242 RVA: 0x0001C688 File Offset: 0x0001A888
		protected override void StartUnityEvent()
		{
			base.StartUnityEvent();
		}

		// Token: 0x060004DB RID: 1243 RVA: 0x0001C690 File Offset: 0x0001A890
		protected override void OnEnableUnityEvent()
		{
			base.OnEnableUnityEvent();
			this.m_Interaccion.comenzada += this.M_Interaccion_comenzada;
			this.m_Interaccion.terminada += this.M_Interaccion_terminada;
		}

		// Token: 0x060004DC RID: 1244 RVA: 0x0001C6C6 File Offset: 0x0001A8C6
		protected override void OnDisableUnityEvent(bool quitting)
		{
			base.OnDisableUnityEvent(quitting);
			this.m_Interaccion.comenzada -= this.M_Interaccion_comenzada;
			this.m_Interaccion.terminada -= this.M_Interaccion_terminada;
		}

		// Token: 0x060004DD RID: 1245 RVA: 0x0001C700 File Offset: 0x0001A900
		private void M_Interaccion_comenzada(Interaccion obj)
		{
			GlobalUpdater.Corrutina coroutine = this.m_Coroutine;
			if (coroutine != null)
			{
				coroutine.Stop();
			}
			CamillaPoseTraslateHandJobInteractionsToGoto.IntersData intersData = new CamillaPoseTraslateHandJobInteractionsToGoto.IntersData(obj);
			this.m_Coroutine = GlobalUpdater.instancia.StartCorrutinaOnEvent<CamillaPoseTraslateHandJobInteractionsToGoto.IntersData>(GlobalUpdater.UpdateType.update1, intersData, this, this.TranslateRutine(intersData), new GlobalUpdater.Corrutina<CamillaPoseTraslateHandJobInteractionsToGoto.IntersData>.OnEndedHandlerConEstado(this.OnEnded_TranslateRutine));
		}

		// Token: 0x060004DE RID: 1246 RVA: 0x0001C74B File Offset: 0x0001A94B
		private void M_Interaccion_terminada(Interaccion obj)
		{
			GlobalUpdater.Corrutina coroutine = this.m_Coroutine;
			if (coroutine != null)
			{
				coroutine.Stop();
			}
			this.m_Coroutine = null;
		}

		// Token: 0x060004DF RID: 1247 RVA: 0x0001C765 File Offset: 0x0001A965
		private IEnumerator TranslateRutine(CamillaPoseTraslateHandJobInteractionsToGoto.IntersData data)
		{
			GoToScenaManager.GoTo GoTo = Singleton<GoToScenaManager>.instance.Obtener("GOTO.camillaHandJob");
			if (GoTo == null)
			{
				Debug.LogError("No se encontro handjob goto", this);
				yield break;
			}
			ManualCorrutina.TValleWaitForSeconds w = new ManualCorrutina.TValleWaitForSeconds(2f.Random(0.2f));
			for (;;)
			{
				data.grabL.adder.toAdd.transform.SetPositionAndRotation(GoTo.transform.position, GoTo.transform.rotation);
				data.grabR.adder.toAdd.transform.SetPositionAndRotation(GoTo.transform.position, GoTo.transform.rotation);
				data.jobL.adder.toAdd.transform.SetPositionAndRotation(GoTo.transform.position, GoTo.transform.rotation);
				data.jobR.adder.toAdd.transform.SetPositionAndRotation(GoTo.transform.position, GoTo.transform.rotation);
				yield return w;
			}
			yield break;
		}

		// Token: 0x060004E0 RID: 1248 RVA: 0x0001C77B File Offset: 0x0001A97B
		private void OnEnded_TranslateRutine(CamillaPoseTraslateHandJobInteractionsToGoto.IntersData estado, MonoBehaviour owner, ManualCorrutina ended, Exception error)
		{
			estado.Restore();
		}

		// Token: 0x040002DC RID: 732
		private Interaccion m_Interaccion;

		// Token: 0x040002DD RID: 733
		private GlobalUpdater.Corrutina m_Coroutine;

		// Token: 0x02000204 RID: 516
		internal class IntersData
		{
			// Token: 0x06000F97 RID: 3991 RVA: 0x0004CA00 File Offset: 0x0004AC00
			public IntersData(Interaccion Interaccion)
			{
				InteraccionAdderOnRange[] componentsInChildren = Interaccion.owner.character.GetComponentsInChildren<InteraccionAdderOnRange>(false);
				InteraccionAdderOnRange interaccionAdderOnRange = componentsInChildren.First((InteraccionAdderOnRange ad) => ad.stringID == "tvalle.inter.HandJobGrabInMaleR");
				InteraccionAdderOnRange interaccionAdderOnRange2 = componentsInChildren.First((InteraccionAdderOnRange ad) => ad.stringID == "tvalle.inter.HandJobGrabInMaleL");
				InteraccionAdderOnRange interaccionAdderOnRange3 = componentsInChildren.First((InteraccionAdderOnRange ad) => ad.stringID == "tvalle.inter.HandJobInMaleR");
				InteraccionAdderOnRange interaccionAdderOnRange4 = componentsInChildren.First((InteraccionAdderOnRange ad) => ad.stringID == "tvalle.inter.HandJobInMaleL");
				this.grabR = new CamillaPoseTraslateHandJobInteractionsToGoto.InterData(interaccionAdderOnRange);
				this.grabL = new CamillaPoseTraslateHandJobInteractionsToGoto.InterData(interaccionAdderOnRange2);
				this.jobR = new CamillaPoseTraslateHandJobInteractionsToGoto.InterData(interaccionAdderOnRange3);
				this.jobL = new CamillaPoseTraslateHandJobInteractionsToGoto.InterData(interaccionAdderOnRange4);
			}

			// Token: 0x06000F98 RID: 3992 RVA: 0x0004CAEB File Offset: 0x0004ACEB
			public void Restore()
			{
				this.grabR.Restore();
				this.grabL.Restore();
				this.jobR.Restore();
				this.jobL.Restore();
			}

			// Token: 0x040009C7 RID: 2503
			public CamillaPoseTraslateHandJobInteractionsToGoto.InterData grabR;

			// Token: 0x040009C8 RID: 2504
			public CamillaPoseTraslateHandJobInteractionsToGoto.InterData grabL;

			// Token: 0x040009C9 RID: 2505
			public CamillaPoseTraslateHandJobInteractionsToGoto.InterData jobR;

			// Token: 0x040009CA RID: 2506
			public CamillaPoseTraslateHandJobInteractionsToGoto.InterData jobL;
		}

		// Token: 0x02000205 RID: 517
		internal class InterData
		{
			// Token: 0x06000F99 RID: 3993 RVA: 0x0004CB19 File Offset: 0x0004AD19
			public InterData(InteraccionAdderOnRange Adder)
			{
				this.adder = Adder;
				this.defaultLocalPosition = Adder.toAdd.transform.localPosition;
				this.defaultLocalRotation = Adder.toAdd.transform.localRotation;
			}

			// Token: 0x06000F9A RID: 3994 RVA: 0x0004CB54 File Offset: 0x0004AD54
			public void Restore()
			{
				this.adder.toAdd.transform.SetLocalPositionAndRotation(this.defaultLocalPosition, this.defaultLocalRotation);
			}

			// Token: 0x040009CB RID: 2507
			public InteraccionAdderOnRange adder;

			// Token: 0x040009CC RID: 2508
			public Vector3 defaultLocalPosition;

			// Token: 0x040009CD RID: 2509
			public Quaternion defaultLocalRotation;
		}
	}
}
