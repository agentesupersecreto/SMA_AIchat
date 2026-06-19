using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace Assets._ReusableScripts.CuchiCuchi.AI.ReactoresDeEstimulos
{
	// Token: 0x02000395 RID: 917
	public abstract class ReactorPadre : ReactorSegundario
	{
		// Token: 0x06001410 RID: 5136 RVA: 0x00056D63 File Offset: 0x00054F63
		protected override void AwakeUnityEvent()
		{
			base.AwakeUnityEvent();
			this.comparison = new Comparison<ReactorSegundario>(ReactorPadre.Comparacion);
		}

		// Token: 0x06001411 RID: 5137 RVA: 0x00056D7D File Offset: 0x00054F7D
		protected override void OnEnableUnityEvent()
		{
			base.OnEnableUnityEvent();
			this.ActualizarHijos();
		}

		// Token: 0x06001412 RID: 5138 RVA: 0x00056D8C File Offset: 0x00054F8C
		protected override void OnDisableUnityEvent(bool quitting)
		{
			base.OnDisableUnityEvent(quitting);
			this.m_hijos = null;
			this.m_muyAlta = null;
			this.m_alta = null;
			this.m_media = null;
			this.m_baja = null;
			this.m_muyBaja = null;
			this.m_extraBaja = null;
			this.m_extraAlta = null;
			this.m_hijosActualizados = false;
		}

		// Token: 0x06001413 RID: 5139 RVA: 0x00056DE0 File Offset: 0x00054FE0
		protected virtual ReactorSegundario[] ObtenerHijos(Transform hijo)
		{
			ReactorSegundario[] array;
			try
			{
				hijo.GetComponentsInChildren<ReactorSegundario>(true, this.temp);
				array = this.temp.Where((ReactorSegundario h) => h.transform == hijo).ToArray<ReactorSegundario>();
			}
			finally
			{
				this.temp.Clear();
			}
			return array;
		}

		// Token: 0x06001414 RID: 5140 RVA: 0x00056E48 File Offset: 0x00055048
		public void ActualizarHijos()
		{
			List<ReactorSegundario> list = new List<ReactorSegundario>();
			int childCount = base.transform.childCount;
			for (int i = 0; i < childCount; i++)
			{
				ReactorSegundario[] array = this.ObtenerHijos(base.transform.GetChild(i));
				list.AddRange(array);
				foreach (ReactorSegundario reactorSegundario in array)
				{
					switch (reactorSegundario.baseConfig.prioridad)
					{
					case ReactorSegundario.Prioridad.normal:
						this.AddToList(ref this.m_media, reactorSegundario);
						break;
					case ReactorSegundario.Prioridad.baja:
						this.AddToList(ref this.m_baja, reactorSegundario);
						break;
					case ReactorSegundario.Prioridad.alta:
						this.AddToList(ref this.m_alta, reactorSegundario);
						break;
					case ReactorSegundario.Prioridad.muyBaja:
						this.AddToList(ref this.m_muyBaja, reactorSegundario);
						break;
					case ReactorSegundario.Prioridad.muyAlta:
						this.AddToList(ref this.m_muyAlta, reactorSegundario);
						break;
					case ReactorSegundario.Prioridad.extraBaja:
						this.AddToList(ref this.m_extraBaja, reactorSegundario);
						break;
					case ReactorSegundario.Prioridad.extraAlta:
						this.AddToList(ref this.m_extraAlta, reactorSegundario);
						break;
					default:
						throw new ArgumentOutOfRangeException(reactorSegundario.baseConfig.prioridad.ToString());
					}
				}
			}
			if (this.m_extraAlta != null)
			{
				this.m_extraAlta.Sort(this.comparison);
			}
			if (this.m_muyAlta != null)
			{
				this.m_muyAlta.Sort(this.comparison);
			}
			if (this.m_alta != null)
			{
				this.m_alta.Sort(this.comparison);
			}
			if (this.m_media != null)
			{
				this.m_media.Sort(this.comparison);
			}
			if (this.m_baja != null)
			{
				this.m_baja.Sort(this.comparison);
			}
			if (this.m_muyBaja != null)
			{
				this.m_muyBaja.Sort(this.comparison);
			}
			if (this.m_extraBaja != null)
			{
				this.m_extraBaja.Sort(this.comparison);
			}
			this.m_hijos = new List<ReactorSegundario>(list.Count);
			if (this.m_extraAlta != null)
			{
				foreach (ReactorSegundario reactorSegundario2 in this.m_extraAlta)
				{
					this.m_hijos.Add(reactorSegundario2);
				}
			}
			if (this.m_muyAlta != null)
			{
				foreach (ReactorSegundario reactorSegundario3 in this.m_muyAlta)
				{
					this.m_hijos.Add(reactorSegundario3);
				}
			}
			if (this.m_alta != null)
			{
				foreach (ReactorSegundario reactorSegundario4 in this.m_alta)
				{
					this.m_hijos.Add(reactorSegundario4);
				}
			}
			if (this.m_media != null)
			{
				foreach (ReactorSegundario reactorSegundario5 in this.m_media)
				{
					this.m_hijos.Add(reactorSegundario5);
				}
			}
			if (this.m_baja != null)
			{
				foreach (ReactorSegundario reactorSegundario6 in this.m_baja)
				{
					this.m_hijos.Add(reactorSegundario6);
				}
			}
			if (this.m_muyBaja != null)
			{
				foreach (ReactorSegundario reactorSegundario7 in this.m_muyBaja)
				{
					this.m_hijos.Add(reactorSegundario7);
				}
			}
			if (this.m_extraBaja != null)
			{
				foreach (ReactorSegundario reactorSegundario8 in this.m_extraBaja)
				{
					this.m_hijos.Add(reactorSegundario8);
				}
			}
			this.m_hijosActualizados = true;
		}

		// Token: 0x06001415 RID: 5141 RVA: 0x00057280 File Offset: 0x00055480
		private void AddToList(ref List<ReactorSegundario> list, ReactorSegundario item)
		{
			if (list == null)
			{
				list = new List<ReactorSegundario>();
			}
			list.Add(item);
		}

		// Token: 0x06001416 RID: 5142 RVA: 0x00003B39 File Offset: 0x00001D39
		protected virtual void FiltrarArgumentos(List<object> args)
		{
		}

		// Token: 0x06001417 RID: 5143 RVA: 0x00057298 File Offset: 0x00055498
		public sealed override bool Reaccionar(object arg)
		{
			this.OnArgumentoReaccionando(arg);
			bool flag = false;
			bool flag2;
			try
			{
				if (!this.m_hijosActualizados)
				{
					flag2 = flag;
				}
				else
				{
					IList list = arg as IList;
					if (list == null || list.Count == 0)
					{
						if (!base.PuedeReaccionar(arg))
						{
							return flag;
						}
					}
					else
					{
						for (int i = 0; i < list.Count; i++)
						{
							object obj = list[i];
							if (base.PuedeReaccionar(obj))
							{
								this.m_tempARGS.Add(obj);
							}
						}
						this.FiltrarArgumentos(this.m_tempARGS);
						arg = this.m_tempARGS;
					}
					bool flag3 = false;
					bool flag4 = false;
					bool flag5 = false;
					int num = 0;
					this.ReaccionarHijos(this.m_extraAlta, arg, ref flag3, ref num);
					this.ReaccionarHijos(this.m_muyAlta, arg, ref flag3, ref num);
					this.ReaccionarHijos(this.m_alta, arg, ref flag3, ref num);
					this.ReaccionarHijos(this.m_media, arg, ref flag3, ref num);
					this.ReaccionarHijos(this.m_baja, arg, ref flag3, ref num);
					this.ReaccionarHijos(this.m_muyBaja, arg, ref flag3, ref num);
					this.ReaccionarHijos(this.m_extraBaja, arg, ref flag3, ref num);
					if (!flag3 || this.padreConfig.reaccionarPropioSiAlgunHijoReacciona)
					{
						bool flag6 = true;
						for (int j = 0; j < this.m_hijos.Count; j++)
						{
							ReactorSegundario reactorSegundario = this.m_hijos[j];
							if (list == null)
							{
								bool flag7;
								if (!reactorSegundario.ReactorPadrePuedeReaccionar(this, arg, out flag7) || flag7)
								{
									flag6 = false;
									if (this.debugLog)
									{
										MonoBehaviour.print("- " + base.name + " negado a reaccionar por hijo: " + reactorSegundario.name);
										break;
									}
									break;
								}
							}
							else
							{
								bool flag8 = false;
								for (int k = this.m_tempARGS.Count - 1; k >= 0; k--)
								{
									object obj2 = this.m_tempARGS[k];
									if (!reactorSegundario.ReactorPadrePuedeReaccionar(this, obj2, out flag8) || flag8)
									{
										if (this.debugLog)
										{
											MonoBehaviour.print("- " + base.name + " negado a reaccionar SINGULAR por hijo: " + reactorSegundario.name);
										}
										if (flag8)
										{
											break;
										}
										this.m_tempARGS.RemoveAt(k);
									}
								}
								flag6 = this.m_tempARGS.Count > 0 && !flag8;
							}
						}
						if (flag6)
						{
							flag5 = true;
							if (list == null)
							{
								flag4 = base.Reacc(arg);
							}
							else
							{
								flag4 = false;
								if (this.m_tempARGS.Count == 0 && this.puedeReaccionarANullos)
								{
									flag4 = base.Reacc(null);
								}
								else
								{
									for (int l = 0; l < this.m_tempARGS.Count; l++)
									{
										object obj3 = this.m_tempARGS[l];
										flag4 = base.Reacc(obj3) || flag4;
										if (flag4 && this.baseConfig.unaSolaReaccionPorFrame)
										{
											break;
										}
									}
								}
							}
						}
					}
					if (this.debugLog)
					{
						MonoBehaviour.print("- cantidad de hijos que reaccionaron (config): " + num.ToString());
						MonoBehaviour.print("- reaccion propia (config): " + this.padreConfig.reaccionarPropioSiAlgunHijoReacciona.ToString());
						MonoBehaviour.print("- cantidad de hijos: " + ((this.m_hijos != null) ? this.m_hijos.Count : 0).ToString());
						MonoBehaviour.print("- resultado de hijos: " + flag3.ToString());
						MonoBehaviour.print("- resultado propio: " + flag4.ToString());
					}
					flag = flag3 || flag4;
					if (!flag5)
					{
						base.PostReaccion(flag, arg);
					}
					flag2 = flag;
				}
			}
			finally
			{
				this.m_lastReaccionFrame = Time.frameCount;
				this.m_lastReaccionResult = flag;
				this.m_tempARGS.Clear();
				this.OnArgumentoReaccionado(arg, flag);
			}
			return flag2;
		}

		// Token: 0x17000500 RID: 1280
		// (get) Token: 0x06001418 RID: 5144
		protected abstract bool puedeReaccionarANullos { get; }

		// Token: 0x06001419 RID: 5145 RVA: 0x00057640 File Offset: 0x00055840
		private void ReaccionarHijos(List<ReactorSegundario> hs, object arg, ref bool reaciono, ref int cantidadDeHijosReaccionando)
		{
			if (reaciono && this.padreConfig.dejarDeReaccionarHijosSiAlgunHijoReacciona)
			{
				return;
			}
			if (hs != null)
			{
				for (int i = 0; i < hs.Count; i++)
				{
					if (hs[i].isActiveAndEnabled)
					{
						bool flag = hs[i].Reaccionar(arg);
						reaciono = reaciono || flag;
						cantidadDeHijosReaccionando++;
						if (reaciono && this.padreConfig.dejarDeReaccionarHijosSiAlgunHijoReacciona)
						{
							break;
						}
					}
				}
			}
		}

		// Token: 0x0600141A RID: 5146
		protected abstract float ModificadorDeProbabilidadPorSegundo(object arg);

		// Token: 0x0600141B RID: 5147 RVA: 0x000576B0 File Offset: 0x000558B0
		protected sealed override float ProbabilidadPorSegundoModificador(object arg)
		{
			float num = this.ModificadorDeProbabilidadPorSegundo(arg);
			if (num <= 0f)
			{
				return 0f;
			}
			if (num == 3.4028235E+38f || num == float.PositiveInfinity)
			{
				return float.MaxValue;
			}
			if (this.m_hijos != null)
			{
				for (int i = 0; i < this.m_hijos.Count; i++)
				{
					ReactorPadre.IProbabilidadPorSegundoModParaPadreListiner probabilidadPorSegundoModParaPadreListiner = this.m_hijos[i] as ReactorPadre.IProbabilidadPorSegundoModParaPadreListiner;
					if (probabilidadPorSegundoModParaPadreListiner != null)
					{
						num *= probabilidadPorSegundoModParaPadreListiner.ModificadorDeProbabilidadPorSegundoParaPadre(this, arg);
					}
				}
			}
			return num;
		}

		// Token: 0x0600141C RID: 5148
		protected abstract float ModificadorDeCoolDown(object arg);

		// Token: 0x0600141D RID: 5149 RVA: 0x00057728 File Offset: 0x00055928
		protected sealed override float CoolDownModificador(object arg)
		{
			float num = this.ModificadorDeCoolDown(arg);
			if (num <= 0f)
			{
				return 0f;
			}
			if (this.m_hijos != null)
			{
				for (int i = 0; i < this.m_hijos.Count; i++)
				{
					ReactorPadre.ICoolDownModParaPadreListiner coolDownModParaPadreListiner = this.m_hijos[i] as ReactorPadre.ICoolDownModParaPadreListiner;
					if (coolDownModParaPadreListiner != null)
					{
						num *= coolDownModParaPadreListiner.ModificadorDeCoolDownParaPadre(this, arg);
					}
				}
			}
			return num;
		}

		// Token: 0x0600141E RID: 5150 RVA: 0x0005778C File Offset: 0x0005598C
		private static int Comparacion(ReactorSegundario x, ReactorSegundario y)
		{
			int prioridadEspecifica = y.baseConfig.prioridadEspecifica;
			int num = prioridadEspecifica;
			if (x != y)
			{
				num = x.baseConfig.prioridadEspecifica;
			}
			return prioridadEspecifica.CompareTo(num);
		}

		// Token: 0x04001087 RID: 4231
		[Header("Como Padre")]
		public ReactorPadreConfig padreConfig = new ReactorPadreConfig();

		// Token: 0x04001088 RID: 4232
		[ReadOnlyUI]
		[SerializeField]
		private List<ReactorSegundario> m_hijos;

		// Token: 0x04001089 RID: 4233
		private List<ReactorSegundario> m_muyAlta;

		// Token: 0x0400108A RID: 4234
		private List<ReactorSegundario> m_alta;

		// Token: 0x0400108B RID: 4235
		private List<ReactorSegundario> m_media;

		// Token: 0x0400108C RID: 4236
		private List<ReactorSegundario> m_baja;

		// Token: 0x0400108D RID: 4237
		private List<ReactorSegundario> m_muyBaja;

		// Token: 0x0400108E RID: 4238
		private List<ReactorSegundario> m_extraBaja;

		// Token: 0x0400108F RID: 4239
		private List<ReactorSegundario> m_extraAlta;

		// Token: 0x04001090 RID: 4240
		private Comparison<ReactorSegundario> comparison;

		// Token: 0x04001091 RID: 4241
		[NonSerialized]
		private bool m_hijosActualizados;

		// Token: 0x04001092 RID: 4242
		private List<ReactorSegundario> temp = new List<ReactorSegundario>();

		// Token: 0x04001093 RID: 4243
		private List<object> m_tempARGS = new List<object>();

		// Token: 0x02000396 RID: 918
		public interface ICoolDownModParaPadreListiner
		{
			// Token: 0x06001420 RID: 5152
			float ModificadorDeCoolDownParaPadre(ReactorPadre padre, object arg);
		}

		// Token: 0x02000397 RID: 919
		public interface IProbabilidadPorSegundoModParaPadreListiner
		{
			// Token: 0x06001421 RID: 5153
			float ModificadorDeProbabilidadPorSegundoParaPadre(ReactorPadre padre, object arg);
		}
	}
}
