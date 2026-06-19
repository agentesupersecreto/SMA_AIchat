using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using Assets.TValle.BeachGirl;
using Assets.TValle.BeachGirl.Estimulos;
using Assets.TValle.BeachGirl.Estimulos.Runtime;
using Assets._ReusableScripts.CuchiCuchi.AI;
using Assets._ReusableScripts.CuchiCuchi.Dependentes.Puppet;
using Assets._ReusableScripts.CuchiCuchi.Estimulos;
using Assets._ReusableScripts.CuchiCuchi.Particulas.Skins;
using Assets._ReusableScripts.CuchiCuchi.Skins;
using UnityEngine;

namespace Assets._ReusableScripts.CuchiCuchi.Dependentes.Characters.Ai
{
	// Token: 0x020002A6 RID: 678
	public class FemaleCharTouchInformerV2 : FemaleInformer, ICharTouchInformerV2
	{
		// Token: 0x06001188 RID: 4488 RVA: 0x00052E98 File Offset: 0x00051098
		protected override void AwakeUnityEvent()
		{
			base.AwakeUnityEvent();
			this.m_FemaleSimpleAi = this.GetComponentEnRoot(false);
			if (this.m_FemaleSimpleAi == null)
			{
				throw new ArgumentNullException("m_FemaleSimpleAi", "m_FemaleSimpleAi null reference.");
			}
			this.m_FemaleChar.stared += this.M_FemaleChar_stared;
			PuppetPartes componentInChildren = this.m_FemaleChar.GetComponentInChildren<PuppetPartes>();
			if (componentInChildren)
			{
				componentInChildren.stared += this.Puppet_stared;
			}
			this.m_comparadorRecibidas = (ValueTuple<ValueTuple<EstimuloTactil, ParteQuePuedeEstimular>, ValueTuple<EstimuloTactil, ParteQuePuedeEstimular>> a, ValueTuple<ValueTuple<EstimuloTactil, ParteQuePuedeEstimular>, ValueTuple<EstimuloTactil, ParteQuePuedeEstimular>> b) => b.Item1.Item1.prioridadGeneral.CompareTo(a.Item1.Item1.prioridadGeneral);
		}

		// Token: 0x06001189 RID: 4489 RVA: 0x00052F38 File Offset: 0x00051138
		private void Puppet_stared(object obj)
		{
			PuppetPartes puppetPartes = obj as PuppetPartes;
			if (puppetPartes == null)
			{
				throw new ArgumentNullException("puppet", "puppet null reference.");
			}
			PartesDePuppet<PuppetPart> partes = puppetPartes.partes;
			HashSetList<PuppetPart> hashSetList = new HashSetList<PuppetPart>();
			hashSetList.Add(partes.cadera);
			hashSetList.Add(partes.spine1);
			hashSetList.Add(partes.spine2);
			hashSetList.Add(partes.head);
			hashSetList.Add(partes.neck);
			foreach (PuppetPart puppetPart in partes.list)
			{
				hashSetList.Add(puppetPart);
			}
			this.m_listaPorPrioridadPartes = hashSetList.ToArray<PuppetPart>();
			this.m_handPuppetR = partes.manoR;
			this.m_handPuppetL = partes.manoL;
			this.m_foreArmPuppetR = partes.anteBrazoR;
			this.m_foreArmPuppetL = partes.anteBrazoL;
			this.m_armPuppetR = partes.brazoR;
			this.m_armPuppetL = partes.brazoL;
		}

		// Token: 0x0600118A RID: 4490 RVA: 0x0005304C File Offset: 0x0005124C
		private void M_FemaleChar_stared(object obj)
		{
			FemaleSkins.HitSkins.Partes partes = this.m_FemaleChar.femaleSkins.hitSkins.partes;
			HashSetList<HitSkinBasica> hashSetList = new HashSetList<HitSkinBasica>();
			hashSetList.Add(partes.clitoris.a);
			hashSetList.Add(partes.clitoris.b);
			hashSetList.Add(partes.labioVaginaleBack);
			hashSetList.Add(partes.labiosVaginales.l);
			hashSetList.Add(partes.labiosVaginales.r);
			hashSetList.Add(partes.anusParedes);
			hashSetList.Add(partes.vagParedes);
			hashSetList.Add(partes.lengua);
			hashSetList.Add(partes.senos002.l);
			hashSetList.Add(partes.senos002.r);
			hashSetList.Add(partes.senos001.l);
			hashSetList.Add(partes.senos001.r);
			hashSetList.Add(partes.senos000.l);
			hashSetList.Add(partes.senos000.r);
			hashSetList.Add(partes.nalgas.l);
			hashSetList.Add(partes.nalgas.r);
			hashSetList.Add(partes.manos.l);
			hashSetList.Add(partes.manos.r);
			hashSetList.Add(partes.cabeza);
			hashSetList.Add(partes.piernas.l);
			hashSetList.Add(partes.piernas.r);
			hashSetList.Add(partes.torzo);
			hashSetList.Add(partes.pies.l);
			hashSetList.Add(partes.pies.r);
			hashSetList.Add(partes.canillas.l);
			hashSetList.Add(partes.canillas.r);
			hashSetList.Add(partes.brazos.l);
			hashSetList.Add(partes.brazos.r);
			hashSetList.Add(partes.anteBrazos.l);
			hashSetList.Add(partes.anteBrazos.r);
			foreach (HitSkinBasica hitSkinBasica in this.m_FemaleChar.femaleSkins.hitSkins.hitSkins)
			{
				hashSetList.Add(hitSkinBasica);
			}
			this.m_listaPorPrioridad = hashSetList.ToArray<HitSkinBasica>();
			HashSetList<SkinSensibleASemen> hashSetList2 = new HashSetList<SkinSensibleASemen>();
			foreach (HitSkinBasica hitSkinBasica2 in this.m_listaPorPrioridad)
			{
				if (!(hitSkinBasica2 == null))
				{
					SkinSensibleASemen component = hitSkinBasica2.GetComponent<SkinSensibleASemen>();
					if (component)
					{
						hashSetList2.Add(component);
					}
				}
			}
			this.m_listaPorPrioridadSemen = hashSetList2.ToArray<SkinSensibleASemen>();
			this.m_handSkinR = partes.manos.r;
			this.m_handSkinL = partes.manos.l;
			this.m_foreArmSkinR = partes.anteBrazos.r;
			this.m_foreArmSkinL = partes.anteBrazos.l;
			this.m_armSkinR = partes.brazos.r;
			this.m_armSkinL = partes.brazos.l;
		}

		// Token: 0x0600118B RID: 4491 RVA: 0x00053398 File Offset: 0x00051598
		public void EstimulosProducidosPor(ICharacter productor, ICharTouchInformerV2User user, DictionaryDeEstimulosTactiles result)
		{
			for (int i = 0; i < this.m_listaPorPrioridad.Length; i++)
			{
				HitSkinBasica hitSkinBasica = this.m_listaPorPrioridad[i];
				this.ProcesarSkin(hitSkinBasica, productor, user, result);
			}
			for (int j = 0; j < this.m_listaPorPrioridadSemen.Length; j++)
			{
				SkinSensibleASemen skinSensibleASemen = this.m_listaPorPrioridadSemen[j];
				this.ProcesarSemenSkin(skinSensibleASemen, skinSensibleASemen.tocadoPorSemenDeMaleChar, productor, user, result);
			}
			for (int k = 0; k < this.m_listaPorPrioridadSemen.Length; k++)
			{
				SkinSensibleASemen skinSensibleASemen2 = this.m_listaPorPrioridadSemen[k];
				this.ProcesarSemenSkin(skinSensibleASemen2, skinSensibleASemen2.tocadoPorWaterDeMaleChar, productor, user, result);
			}
			for (int l = 0; l < this.m_listaPorPrioridadSemen.Length; l++)
			{
				SkinSensibleASemen skinSensibleASemen3 = this.m_listaPorPrioridadSemen[l];
				this.ProcesarSemenSkin(skinSensibleASemen3, skinSensibleASemen3.tocadoPorLubeDeMaleChar, productor, user, result);
			}
			for (int m = 0; m < this.m_listaPorPrioridadPartes.Length; m++)
			{
				PuppetPart puppetPart = this.m_listaPorPrioridadPartes[m];
				this.ProcesarParte(puppetPart, productor, user, result);
			}
			if (this.debug)
			{
				MonoBehaviour.print("****Estimulos Tactiles : " + result.Count.ToString());
				foreach (KeyValuePair<ValueTuple<int, int>, ValueTuple<EstimuloTactil, ValueTuple<EstimuloTactil, int>>> keyValuePair in result)
				{
					foreach (ParteDelCuerpoHumano parteDelCuerpoHumano in keyValuePair.Value.Item1.partesDelCuerpoHumanoEstimuladas)
					{
						MonoBehaviour.print("parte : " + parteDelCuerpoHumano.ToString());
					}
				}
			}
			if (this.debugDraw)
			{
				foreach (KeyValuePair<ValueTuple<int, int>, ValueTuple<EstimuloTactil, ValueTuple<EstimuloTactil, int>>> keyValuePair2 in result)
				{
				}
			}
		}

		// Token: 0x0600118C RID: 4492 RVA: 0x00053590 File Offset: 0x00051790
		private void ProcesarSemenSkin(SkinSensibleASemen skin, SkinSensibleASemen.TocadoPorSemenDeChar tocadoPor, ICharacter productor, ICharTouchInformerV2User user, DictionaryDeEstimulosTactiles result)
		{
			if (skin == null || !skin.isActiveAndEnabled)
			{
				return;
			}
			ParteQuePuedeEstimular parteQuePuedeEstimular = ParteQuePuedeEstimular.semen;
			EstimuloTactilDeSemen estimuloTactilDeSemen;
			if (!tocadoPor.ContieneEstimuloV3<EstimuloTactilDeSemen>(productor, out estimuloTactilDeSemen))
			{
				return;
			}
			ValueTuple<EstimuloTactil, ValueTuple<EstimuloTactil, int>> valueTuple;
			if (result.TryGetValue(estimuloTactilDeSemen.tipo, parteQuePuedeEstimular, out valueTuple))
			{
				valueTuple.Item1.AddPartesEstimuladas(estimuloTactilDeSemen.partesDelCuerpoHumanoEstimuladas);
				return;
			}
			EstimuloTactilDeSemen estimuloTactilDeSemen2 = user.ProducirInstancia<EstimuloTactilDeSemen>();
			if (estimuloTactilDeSemen2 == null)
			{
				throw new ArgumentNullException("instance", "instance null reference.");
			}
			estimuloTactilDeSemen.CopiarA(estimuloTactilDeSemen2, false);
			result.Add(estimuloTactilDeSemen2.tipo, parteQuePuedeEstimular, new ValueTuple<EstimuloTactil, ValueTuple<EstimuloTactil, int>>(estimuloTactilDeSemen2, new ValueTuple<EstimuloTactil, int>(null, 0)));
		}

		// Token: 0x0600118D RID: 4493 RVA: 0x00053624 File Offset: 0x00051824
		private void ProcesarSkin(HitSkinBasica skin, ICharacter productor, ICharTouchInformerV2User user, DictionaryDeEstimulosTactiles result)
		{
			try
			{
				if (!(skin == null) && skin.isActiveAndEnabled)
				{
					bool flag = skin == this.m_handSkinR || skin == this.m_foreArmSkinR || skin == this.m_armSkinR;
					bool flag2 = skin == this.m_handSkinL || skin == this.m_foreArmSkinL || skin == this.m_armSkinL;
					bool flag3 = false;
					if (flag)
					{
						flag3 |= this.m_FemaleSimpleAi.GetIsInteractingWithHerHandsMassage(Side.R);
					}
					if (flag2)
					{
						flag3 |= this.m_FemaleSimpleAi.GetIsInteractingWithHerHandsMassage(Side.L);
					}
					this.ProcesarSkin(productor, skin, FemaleCharTouchInformerV2.m_TEMP_estimulosResult);
					FemaleCharTouchInformerV2.m_TEMP_estimulosResult.Sort(this.m_comparadorRecibidas);
					FemaleCharTouchInformerV2.Procesar(user, flag3, result);
				}
			}
			finally
			{
				FemaleCharTouchInformerV2.m_TEMP_estimulosResult.Clear();
			}
		}

		// Token: 0x0600118E RID: 4494 RVA: 0x00053708 File Offset: 0x00051908
		private static void Procesar(ICharTouchInformerV2User user, bool necesitaCopiaInvertida, DictionaryDeEstimulosTactiles result)
		{
			for (int i = 0; i < FemaleCharTouchInformerV2.m_TEMP_estimulosResult.Count; i++)
			{
				ValueTuple<ValueTuple<EstimuloTactil, ParteQuePuedeEstimular>, ValueTuple<EstimuloTactil, ParteQuePuedeEstimular>> valueTuple = FemaleCharTouchInformerV2.m_TEMP_estimulosResult[i];
				if (valueTuple.Item1.Item2 == ParteQuePuedeEstimular.None)
				{
					return;
				}
				ValueTuple<int, int> valueTuple2;
				if (FemaleCharTouchInformerV2.ProcesarReal(valueTuple, user, result, out valueTuple2))
				{
					FemaleCharTouchInformerV2.GenerarProcesarInvertida(valueTuple, user, necesitaCopiaInvertida, result, valueTuple2);
				}
			}
		}

		// Token: 0x0600118F RID: 4495 RVA: 0x0005375C File Offset: 0x0005195C
		private static bool ProcesarReal(ValueTuple<ValueTuple<EstimuloTactil, ParteQuePuedeEstimular>, ValueTuple<EstimuloTactil, ParteQuePuedeEstimular>> pares, ICharTouchInformerV2User user, DictionaryDeEstimulosTactiles result, [TupleElementNames(new string[] { "direccion", "estimulante" })] out ValueTuple<int, int> key)
		{
			ParteQuePuedeEstimular item = pares.Item1.Item2;
			EstimuloTactil item2 = pares.Item1.Item1;
			key = new ValueTuple<int, int>((int)item2.tipo, (int)item);
			ValueTuple<EstimuloTactil, ValueTuple<EstimuloTactil, int>> valueTuple;
			if (result.TryGetValue(key, out valueTuple))
			{
				valueTuple.Item1.AddPartesEstimuladas(item2.partesDelCuerpoHumanoEstimuladas);
				return false;
			}
			EstimuloTactil estimuloTactil = user.ProducirInstancia<EstimuloTactil>();
			if (estimuloTactil == null)
			{
				throw new ArgumentNullException("instance", "instance null reference.");
			}
			item2.CopiarA(estimuloTactil, false);
			EstimuloTactil estimuloTactil2 = null;
			if (item2.tieneCopiaInvertida)
			{
				InteracionEstimulanteBasica item3 = pares.Item2.Item1;
				estimuloTactil2 = user.ProducirInstancia<EstimuloTactil>();
				if (estimuloTactil2 == null)
				{
					throw new ArgumentNullException("instanceInv", "instanceInv null reference.");
				}
				item3.CopiarA(estimuloTactil2, false);
			}
			valueTuple = new ValueTuple<EstimuloTactil, ValueTuple<EstimuloTactil, int>>(estimuloTactil, new ValueTuple<EstimuloTactil, int>(estimuloTactil2, (int)pares.Item2.Item2));
			result.Add(key, valueTuple);
			return true;
		}

		// Token: 0x06001190 RID: 4496 RVA: 0x0005383C File Offset: 0x00051A3C
		private static void GenerarProcesarInvertida(ValueTuple<ValueTuple<EstimuloTactil, ParteQuePuedeEstimular>, ValueTuple<EstimuloTactil, ParteQuePuedeEstimular>> pares, ICharTouchInformerV2User user, bool necesitaCopiaInvertida, DictionaryDeEstimulosTactiles result, [TupleElementNames(new string[] { "direccion", "estimulante" })] ValueTuple<int, int> key)
		{
			if (!necesitaCopiaInvertida)
			{
				return;
			}
			EstimuloTactil item = pares.Item1.Item1;
			if (item.tieneCopiaInvertida)
			{
				return;
			}
			if (item.tipo == DireccionDeEstimulo.dada)
			{
				return;
			}
			ParteQuePuedeEstimular item2 = pares.Item1.Item2;
			EstimuloTactil estimuloTactil = user.ProducirInstancia<EstimuloTactil>();
			if (estimuloTactil == null)
			{
				throw new ArgumentNullException("instance", "instance null reference.");
			}
			item.CopiarA(estimuloTactil, false);
			((IInteracionEstimulanteReutilizable)estimuloTactil).GenerateNewID();
			FemaleCharTouchInformerV2.AlternarADada(estimuloTactil, ref item2);
			ValueTuple<EstimuloTactil, ValueTuple<EstimuloTactil, int>> valueTuple;
			if (!result.TryGetValue(key, out valueTuple))
			{
				Debug.LogError("deberia haber encotrado item");
				user.RetornarInstancia<EstimuloTactil>(estimuloTactil);
				return;
			}
			((IInteracionEstimulanteInversible)estimuloTactil).SetAsInvertedCopy(valueTuple.Item1);
			estimuloTactil.SetTipoDeEstimuloTactil(TipoDeEstimuloTactilInvertido.massage);
			valueTuple.Item2 = new ValueTuple<EstimuloTactil, int>(estimuloTactil, (int)item2);
			result[key] = valueTuple;
		}

		// Token: 0x06001191 RID: 4497 RVA: 0x000538F4 File Offset: 0x00051AF4
		private static void AlternarADada(EstimuloTactil instance, ref ParteQuePuedeEstimular parteEstimulante)
		{
			instance.tipo = DireccionDeEstimulo.dada;
			ParteDelCuerpoHumano parteDelCuerpoHumano = instance.PartePrincipalEstimulada(PrioridadDeParteDelCuerpoHumanoContexto.@fixed);
			ParteDelCuerpoHumano parteDelCuerpoHumano2 = parteEstimulante.Switch();
			parteEstimulante = parteDelCuerpoHumano.Switch();
			instance.ClearPartesEstimuladas();
			instance.AddParteEstimulada(parteDelCuerpoHumano2);
			((IInteracionEstimulanteInversible)instance).SwitchReferencias();
		}

		// Token: 0x06001192 RID: 4498 RVA: 0x00053934 File Offset: 0x00051B34
		private void ProcesarParte(PuppetPart parte, ICharacter productor, ICharTouchInformerV2User user, DictionaryDeEstimulosTactiles result)
		{
			try
			{
				if (!(parte == null) && parte.isActiveAndEnabled)
				{
					bool flag = parte == this.m_handPuppetR || parte == this.m_foreArmPuppetR || parte == this.m_armPuppetR;
					bool flag2 = parte == this.m_handPuppetL || parte == this.m_foreArmPuppetL || parte == this.m_armPuppetL;
					bool flag3 = false;
					if (flag)
					{
						flag3 |= this.m_FemaleSimpleAi.GetIsInteractingWithHerHandsMassage(Side.R);
					}
					if (flag2)
					{
						flag3 |= this.m_FemaleSimpleAi.GetIsInteractingWithHerHandsMassage(Side.L);
					}
					this.ProcesarParte(productor, parte, FemaleCharTouchInformerV2.m_TEMP_estimulosResult);
					FemaleCharTouchInformerV2.m_TEMP_estimulosResult.Sort(this.m_comparadorRecibidas);
					FemaleCharTouchInformerV2.Procesar(user, flag3, result);
				}
			}
			finally
			{
				FemaleCharTouchInformerV2.m_TEMP_estimulosResult.Clear();
			}
		}

		// Token: 0x06001193 RID: 4499 RVA: 0x00053A18 File Offset: 0x00051C18
		private void ProcesarSkin(ICharacter productor, HitSkinBasica skin, List<ValueTuple<ValueTuple<EstimuloTactil, ParteQuePuedeEstimular>, ValueTuple<EstimuloTactil, ParteQuePuedeEstimular>>> Result)
		{
			try
			{
				if (skin.IsTouchedBy(productor, this.m_TempEstimuloTactilTuched))
				{
					for (int i = 0; i < this.m_TempEstimuloTactilTuched.Count; i++)
					{
						EstimuloTactil estimuloTactil = this.m_TempEstimuloTactilTuched[i];
						this.m_TempEstimuloTactilTuchedDicc.Add(estimuloTactil.estimuloID, estimuloTactil);
					}
					for (int j = 0; j < this.m_TempEstimuloTactilTuched.Count; j++)
					{
						EstimuloTactil estimuloTactil2 = this.m_TempEstimuloTactilTuched[j];
						ParteQuePuedeEstimular estimulante = FemaleCharTouchInformerV2.GetEstimulante(estimuloTactil2, productor, this.m_FemaleChar, true);
						if (!estimuloTactil2.esCopiaInvertida)
						{
							if (!estimuloTactil2.tieneCopiaInvertida)
							{
								Result.Add(new ValueTuple<ValueTuple<EstimuloTactil, ParteQuePuedeEstimular>, ValueTuple<EstimuloTactil, ParteQuePuedeEstimular>>(new ValueTuple<EstimuloTactil, ParteQuePuedeEstimular>(estimuloTactil2, estimulante), new ValueTuple<EstimuloTactil, ParteQuePuedeEstimular>(null, ParteQuePuedeEstimular.None)));
							}
							else
							{
								EstimuloTactil estimuloTactil3 = this.m_TempEstimuloTactilTuchedDicc[estimuloTactil2.estimuloInvertidoID];
								ParteQuePuedeEstimular estimulante2 = FemaleCharTouchInformerV2.GetEstimulante(estimuloTactil3, productor, this.m_FemaleChar, true);
								Result.Add(new ValueTuple<ValueTuple<EstimuloTactil, ParteQuePuedeEstimular>, ValueTuple<EstimuloTactil, ParteQuePuedeEstimular>>(new ValueTuple<EstimuloTactil, ParteQuePuedeEstimular>(estimuloTactil2, estimulante), new ValueTuple<EstimuloTactil, ParteQuePuedeEstimular>(estimuloTactil3, estimulante2)));
							}
						}
					}
				}
			}
			finally
			{
				this.m_TempEstimuloTactilTuchedDicc.Clear();
				this.m_TempEstimuloTactilTuched.Clear();
			}
		}

		// Token: 0x06001194 RID: 4500 RVA: 0x00053B3C File Offset: 0x00051D3C
		private void ProcesarParte(ICharacter productor, PuppetPart parte, List<ValueTuple<ValueTuple<EstimuloTactil, ParteQuePuedeEstimular>, ValueTuple<EstimuloTactil, ParteQuePuedeEstimular>>> Result)
		{
			try
			{
				if (parte.IsTouchedBy(productor, this.m_TempEstimuloTactilTuched))
				{
					for (int i = 0; i < this.m_TempEstimuloTactilTuched.Count; i++)
					{
						EstimuloTactil estimuloTactil = this.m_TempEstimuloTactilTuched[i];
						this.m_TempEstimuloTactilTuchedDicc.Add(estimuloTactil.estimuloID, estimuloTactil);
					}
					for (int j = 0; j < this.m_TempEstimuloTactilTuched.Count; j++)
					{
						EstimuloTactil estimuloTactil2 = this.m_TempEstimuloTactilTuched[j];
						ParteQuePuedeEstimular estimulante = FemaleCharTouchInformerV2.GetEstimulante(estimuloTactil2, productor, this.m_FemaleChar, false);
						if (!estimuloTactil2.esCopiaInvertida)
						{
							if (!estimuloTactil2.tieneCopiaInvertida)
							{
								Result.Add(new ValueTuple<ValueTuple<EstimuloTactil, ParteQuePuedeEstimular>, ValueTuple<EstimuloTactil, ParteQuePuedeEstimular>>(new ValueTuple<EstimuloTactil, ParteQuePuedeEstimular>(estimuloTactil2, estimulante), new ValueTuple<EstimuloTactil, ParteQuePuedeEstimular>(null, ParteQuePuedeEstimular.None)));
							}
							else
							{
								EstimuloTactil estimuloTactil3 = this.m_TempEstimuloTactilTuchedDicc[estimuloTactil2.estimuloInvertidoID];
								ParteQuePuedeEstimular estimulante2 = FemaleCharTouchInformerV2.GetEstimulante(estimuloTactil3, productor, this.m_FemaleChar, false);
								Result.Add(new ValueTuple<ValueTuple<EstimuloTactil, ParteQuePuedeEstimular>, ValueTuple<EstimuloTactil, ParteQuePuedeEstimular>>(new ValueTuple<EstimuloTactil, ParteQuePuedeEstimular>(estimuloTactil2, estimulante), new ValueTuple<EstimuloTactil, ParteQuePuedeEstimular>(estimuloTactil3, estimulante2)));
							}
						}
					}
				}
			}
			finally
			{
				this.m_TempEstimuloTactilTuchedDicc.Clear();
				this.m_TempEstimuloTactilTuched.Clear();
			}
		}

		// Token: 0x06001195 RID: 4501 RVA: 0x00053C60 File Offset: 0x00051E60
		private static ParteQuePuedeEstimular GetEstimulante(EstimuloTactil est, ICharacter productor, FemaleChar m_FemaleChar, bool puedeSerManos)
		{
			ParteQuePuedeEstimular parteQuePuedeEstimular;
			if (((est != null) ? new bool?(((IInteracionEstimulanteBasica)est).esCopiaInvertida) : null).GetValueOrDefault())
			{
				parteQuePuedeEstimular = m_FemaleChar.ParteQuePuedeEstimularDeTransform(est.transformEstimulante);
			}
			else
			{
				parteQuePuedeEstimular = productor.ParteQuePuedeEstimularDeTransform(est.transformEstimulante);
				if (!puedeSerManos && parteQuePuedeEstimular == ParteQuePuedeEstimular.manos)
				{
					parteQuePuedeEstimular = ParteQuePuedeEstimular.torzo;
				}
			}
			return parteQuePuedeEstimular;
		}

		// Token: 0x04000CE4 RID: 3300
		private SkinSensibleASemen[] m_listaPorPrioridadSemen = new SkinSensibleASemen[0];

		// Token: 0x04000CE5 RID: 3301
		private HitSkinBasica[] m_listaPorPrioridad = new HitSkinBasica[0];

		// Token: 0x04000CE6 RID: 3302
		private HitSkinBasica m_handSkinR;

		// Token: 0x04000CE7 RID: 3303
		private HitSkinBasica m_handSkinL;

		// Token: 0x04000CE8 RID: 3304
		private HitSkinBasica m_foreArmSkinR;

		// Token: 0x04000CE9 RID: 3305
		private HitSkinBasica m_foreArmSkinL;

		// Token: 0x04000CEA RID: 3306
		private HitSkinBasica m_armSkinR;

		// Token: 0x04000CEB RID: 3307
		private HitSkinBasica m_armSkinL;

		// Token: 0x04000CEC RID: 3308
		private PuppetPart m_handPuppetR;

		// Token: 0x04000CED RID: 3309
		private PuppetPart m_handPuppetL;

		// Token: 0x04000CEE RID: 3310
		private PuppetPart m_foreArmPuppetR;

		// Token: 0x04000CEF RID: 3311
		private PuppetPart m_foreArmPuppetL;

		// Token: 0x04000CF0 RID: 3312
		private PuppetPart m_armPuppetR;

		// Token: 0x04000CF1 RID: 3313
		private PuppetPart m_armPuppetL;

		// Token: 0x04000CF2 RID: 3314
		private PuppetPart[] m_listaPorPrioridadPartes = new PuppetPart[0];

		// Token: 0x04000CF3 RID: 3315
		private Comparison<ValueTuple<ValueTuple<EstimuloTactil, ParteQuePuedeEstimular>, ValueTuple<EstimuloTactil, ParteQuePuedeEstimular>>> m_comparadorRecibidas;

		// Token: 0x04000CF4 RID: 3316
		private FemaleSimpleAi m_FemaleSimpleAi;

		// Token: 0x04000CF5 RID: 3317
		private static List<ValueTuple<ValueTuple<EstimuloTactil, ParteQuePuedeEstimular>, ValueTuple<EstimuloTactil, ParteQuePuedeEstimular>>> m_TEMP_estimulosResult = new List<ValueTuple<ValueTuple<EstimuloTactil, ParteQuePuedeEstimular>, ValueTuple<EstimuloTactil, ParteQuePuedeEstimular>>>();

		// Token: 0x04000CF6 RID: 3318
		private List<EstimuloTactil> m_TempEstimuloTactilTuched = new List<EstimuloTactil>();

		// Token: 0x04000CF7 RID: 3319
		private Dictionary<Guid, EstimuloTactil> m_TempEstimuloTactilTuchedDicc = new Dictionary<Guid, EstimuloTactil>();
	}
}
