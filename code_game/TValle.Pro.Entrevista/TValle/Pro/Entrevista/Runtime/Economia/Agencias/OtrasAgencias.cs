using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using Assets.SingletonesAndSystemasGlobales.AbstractLayer.Globales;
using Assets.TValle.BeachGirl.Genetica.Alteradores.Runtime.Interpretadores;
using Assets.TValle.Pro.Entrevista.Runtime.Economia.Agencias.Mapas;
using Assets._ReusableScripts.CuchiCuchi;
using Assets._ReusableScripts.CuchiCuchi.Dependentes.BuffAndDebuff;
using UnityEngine;

namespace Assets.TValle.Pro.Entrevista.Runtime.Economia.Agencias
{
	// Token: 0x020000CA RID: 202
	[ProveedorDeAgenciasIds("ids")]
	public class OtrasAgencias : Singleton<OtrasAgencias>
	{
		// Token: 0x170000AA RID: 170
		// (get) Token: 0x0600078F RID: 1935 RVA: 0x0002ABCB File Offset: 0x00028DCB
		public static ICollection<string> ids
		{
			get
			{
				return Singleton<OtrasAgencias>.instance.m_agenciasDeId.Keys;
			}
		}

		// Token: 0x170000AB RID: 171
		// (get) Token: 0x06000790 RID: 1936 RVA: 0x0002ABDC File Offset: 0x00028DDC
		public IReadOnlyList<Agencia> agencias
		{
			get
			{
				return this.m_agencias;
			}
		}

		// Token: 0x170000AC RID: 172
		// (get) Token: 0x06000791 RID: 1937 RVA: 0x0002ABE4 File Offset: 0x00028DE4
		public OtrasAgencias.IncomeChangeBuffAndDebuff incomeChangeBuffAndDebuff
		{
			get
			{
				return this.m_IncomeChangeBuffAndDebuff;
			}
		}

		// Token: 0x06000792 RID: 1938 RVA: 0x0002ABEC File Offset: 0x00028DEC
		protected override void InitData(bool esEditorTime)
		{
			base.InitData(esEditorTime);
			this.m_agenciasDeId.Clear();
			for (int i = 0; i < this.m_agencias.Count; i++)
			{
				Agencia agencia = this.m_agencias[i];
				if (!agencia.isValid)
				{
					Debug.LogError("Agencia: " + agencia.name + " no es valida", agencia);
				}
				try
				{
					this.m_agenciasDeId.Add(agencia.ID, agencia);
				}
				catch (Exception ex)
				{
					throw ex;
				}
			}
		}

		// Token: 0x06000793 RID: 1939 RVA: 0x0002AC78 File Offset: 0x00028E78
		public Agencia ObtenerAgencia(string id)
		{
			Agencia agencia;
			if (this.m_agenciasDeId.TryGetValue(id, out agencia))
			{
				return agencia;
			}
			Debug.LogError("No se encontro agencia con id: " + id, this);
			return null;
		}

		// Token: 0x06000794 RID: 1940 RVA: 0x0002ACA9 File Offset: 0x00028EA9
		public sealed override SingletonEditorBotones Boton2()
		{
			return new SingletonEditorBotones
			{
				playTimeVisible = false,
				text = "Cargar Mapas De Agencias \n usar refresh o reimport si no los quiere cargar"
			};
		}

		// Token: 0x06000795 RID: 1941 RVA: 0x0002ACC2 File Offset: 0x00028EC2
		public override void Aplicar2()
		{
			base.Aplicar2();
		}

		// Token: 0x06000796 RID: 1942 RVA: 0x0002ACCC File Offset: 0x00028ECC
		public static void GetMsgDeRequerimientoV2(Agencia.RequerimientoBase requerimeinto, out StringBuilder label, out StringBuilder value)
		{
			try
			{
				label = new StringBuilder();
				value = new StringBuilder();
				PropertyInfo memberNestedOptimizado = typeof(InterpretacionCompletaDeFemale).GetMemberNestedOptimizado(BindingFlags.Instance | BindingFlags.Public, requerimeinto.rutaSeparada, OtrasAgencias.m_acendenciaTemp);
				Enum @enum = (Enum)Enum.ToObject(memberNestedOptimizado.PropertyType, requerimeinto.valorPrimario);
				Enum enum2 = (Enum)Enum.ToObject(memberNestedOptimizado.PropertyType, requerimeinto.valorSegundario);
				Enum enum3 = (Enum)Enum.ToObject(memberNestedOptimizado.PropertyType, requerimeinto.valorTerciario);
				for (int i = 0; i < OtrasAgencias.m_acendenciaTemp.Count; i++)
				{
					MemberInfo memberInfo = OtrasAgencias.m_acendenciaTemp[i];
					string text;
					try
					{
						text = (Attribute.GetCustomAttribute(memberInfo, typeof(LabelLocalizadoAttribute)) as LabelLocalizadoAttribute).text;
					}
					catch (Exception ex)
					{
						throw ex;
					}
					if (!string.IsNullOrWhiteSpace(text))
					{
						label.Append(text);
						label.Append(',');
						label.Append(' ');
					}
				}
				label.Append((Attribute.GetCustomAttribute(memberNestedOptimizado, typeof(LabelLocalizadoAttribute)) as LabelLocalizadoAttribute).text);
				value.Append(TextoLocalizadoAttribute.Localizado(memberNestedOptimizado.PropertyType, @enum, "US").FirstLetterToUpperCaseOthersToLower());
				if (requerimeinto.usarValorSegundario)
				{
					value.Append(',');
					value.Append(' ');
					value.Append(TextoLocalizadoAttribute.Localizado(memberNestedOptimizado.PropertyType, enum2, "US").FirstLetterToUpperCaseOthersToLower());
				}
				if (requerimeinto.usarValorTerciario)
				{
					value.Append(',');
					value.Append(' ');
					value.Append(TextoLocalizadoAttribute.Localizado(memberNestedOptimizado.PropertyType, enum3, "US").FirstLetterToUpperCaseOthersToLower());
				}
			}
			finally
			{
				OtrasAgencias.m_acendenciaTemp.Clear();
			}
		}

		// Token: 0x06000797 RID: 1943 RVA: 0x0002AEAC File Offset: 0x000290AC
		public static StringBuilder GetMsgDeRequerimientoV2(Agencia.RequerimientoBase requerimeinto)
		{
			StringBuilder stringBuilder;
			StringBuilder stringBuilder2;
			OtrasAgencias.GetMsgDeRequerimientoV2(requerimeinto, out stringBuilder, out stringBuilder2);
			stringBuilder.Append(':');
			stringBuilder.Append(' ');
			stringBuilder.Append(stringBuilder2);
			return stringBuilder;
		}

		// Token: 0x06000798 RID: 1944 RVA: 0x0002AEE0 File Offset: 0x000290E0
		[Obsolete]
		private static StringBuilder GetMsgDeRequerimiento(Agencia.RequerimientoBase requerimeinto)
		{
			StringBuilder stringBuilder = new StringBuilder();
			PropertyInfo memberNestedOptimizado = typeof(InterpretacionCompletaDeFemale).GetMemberNestedOptimizado(BindingFlags.Instance | BindingFlags.Public, requerimeinto.rutaSeparada, null);
			Enum @enum = (Enum)Enum.ToObject(memberNestedOptimizado.PropertyType, requerimeinto.valorPrimario);
			Enum enum2 = (Enum)Enum.ToObject(memberNestedOptimizado.PropertyType, requerimeinto.valorSegundario);
			Enum enum3 = (Enum)Enum.ToObject(memberNestedOptimizado.PropertyType, requerimeinto.valorTerciario);
			stringBuilder.Append((Attribute.GetCustomAttribute(memberNestedOptimizado, typeof(LabelLocalizadoAttribute)) as LabelLocalizadoAttribute).text);
			stringBuilder.Append('=');
			stringBuilder.Append(' ');
			stringBuilder.Append(TextoLocalizadoAttribute.Localizado(memberNestedOptimizado.PropertyType, @enum, "US").FirstLetterToUpperCaseOthersToLower());
			if (requerimeinto.usarValorSegundario)
			{
				stringBuilder.Append(',');
				stringBuilder.Append(' ');
				stringBuilder.Append(TextoLocalizadoAttribute.Localizado(memberNestedOptimizado.PropertyType, enum2, "US").FirstLetterToUpperCaseOthersToLower());
			}
			if (requerimeinto.usarValorTerciario)
			{
				stringBuilder.Append(',');
				stringBuilder.Append(' ');
				stringBuilder.Append(TextoLocalizadoAttribute.Localizado(memberNestedOptimizado.PropertyType, enum3, "US").FirstLetterToUpperCaseOthersToLower());
			}
			return stringBuilder;
		}

		// Token: 0x06000799 RID: 1945 RVA: 0x0002B014 File Offset: 0x00029214
		public string GetMsgModeloNoAsistio(string agenciaID, string modeloID)
		{
			Agencia agencia = this.ObtenerAgencia(agenciaID);
			if (agencia == null)
			{
				throw new ArgumentNullException("agencia", "agencia null reference.");
			}
			Character character = Singleton<CharacteresActivos>.instance.Obtener<Character>(modeloID);
			if (character == null)
			{
				throw new ArgumentNullException("modelo", "modelo null reference.");
			}
			StringBuilder stringBuilder = new StringBuilder();
			Agencia.MensajesDeRequerimiento inicio = agencia.mensajes.inicio;
			if (string.IsNullOrWhiteSpace((inicio != null) ? inicio.negativo : null))
			{
				stringBuilder.Append(string.Format(this.m_IniciosPorDefecto.inicio.negativo, character.nombreCompleto));
			}
			else
			{
				stringBuilder.Append(string.Format(agencia.mensajes.inicio.negativo, character.nombreCompleto));
			}
			stringBuilder.Append(' ');
			if (!string.IsNullOrWhiteSpace(agencia.mensajes.cuerpoModeloNoAsistioEntrevista.msg))
			{
				stringBuilder.Append(agencia.mensajes.cuerpoModeloNoAsistioEntrevista.msg);
			}
			else
			{
				stringBuilder.Append(this.m_CuerposPorDefecto.cuerpoNoAsistio.msg);
			}
			return stringBuilder.ToString();
		}

		// Token: 0x0600079A RID: 1946 RVA: 0x0002B128 File Offset: 0x00029328
		public string GetMsgUnloked(string agenciaID)
		{
			Agencia agencia = this.ObtenerAgencia(agenciaID);
			if (agencia == null)
			{
				throw new ArgumentNullException("agencia", "agencia null reference.");
			}
			StringBuilder stringBuilder = new StringBuilder();
			Agencia.MensajesDeRequerimientoSingle unLocked = agencia.mensajes.unLocked;
			if (string.IsNullOrWhiteSpace((unLocked != null) ? unLocked.msg : null))
			{
				stringBuilder.Append(string.Format(this.m_CuerposPorDefecto.cuerpoUnlocked.msg, agencia.nombre));
			}
			else
			{
				stringBuilder.Append(string.Format(agencia.mensajes.unLocked.msg, agencia.nombre));
			}
			return stringBuilder.ToString();
		}

		// Token: 0x0600079B RID: 1947 RVA: 0x0002B1C8 File Offset: 0x000293C8
		public string GetMsgModelo(string agenciaID, string modeloID, AgenciasHelper.Respuesta respuesta)
		{
			Agencia agencia = this.ObtenerAgencia(agenciaID);
			if (agencia == null)
			{
				throw new ArgumentNullException("agencia", "agencia null reference.");
			}
			Character character = Singleton<CharacteresActivos>.instance.Obtener<Character>(modeloID);
			if (character == null)
			{
				throw new ArgumentNullException("modelo", "modelo null reference.");
			}
			StringBuilder stringBuilder = new StringBuilder();
			HashSet<string> hashSet = new HashSet<string>();
			if (respuesta.esAceptada)
			{
				Agencia.MensajesDeRequerimiento inicio = agencia.mensajes.inicio;
				if (string.IsNullOrWhiteSpace((inicio != null) ? inicio.positivo : null))
				{
					stringBuilder.Append(string.Format(this.m_IniciosPorDefecto.inicio.positivo, character.nombreCompleto));
				}
				else
				{
					stringBuilder.Append(string.Format(agencia.mensajes.inicio.positivo, character.nombreCompleto));
				}
				stringBuilder.Append(' ');
				hashSet.Clear();
				stringBuilder.Append(' ');
				Agencia.Requerimiento requerimiento = respuesta.requerimientosActivados.RandomItemReadOnly<Agencia.Requerimiento>();
				if (requerimiento == null)
				{
					Agencia.MensajesDeRequerimientoSingle cuerpoSinRequerimientos = agencia.mensajes.cuerpoSinRequerimientos;
					if (string.IsNullOrWhiteSpace((cuerpoSinRequerimientos != null) ? cuerpoSinRequerimientos.msg : null))
					{
						if (hashSet.Add(this.m_CuerposPorDefecto.cuerpoSinRequerimientos.msg))
						{
							stringBuilder.Append(this.m_CuerposPorDefecto.cuerpoSinRequerimientos.msg);
						}
					}
					else if (hashSet.Add(agencia.mensajes.cuerpoSinRequerimientos.msg))
					{
						stringBuilder.Append(agencia.mensajes.cuerpoSinRequerimientos.msg);
					}
				}
				else
				{
					Agencia.MensajesDeRequerimiento mensajesDeRequerimiento = requerimiento.mensajesDeRequerimiento;
					if (string.IsNullOrWhiteSpace((mensajesDeRequerimiento != null) ? mensajesDeRequerimiento.positivo : null))
					{
						string text = OtrasAgencias.GetMsgDeRequerimientoV2(requerimiento).ToString();
						text = string.Format(this.m_CuerposPorDefecto.cuerpo.positivo, text);
						if (hashSet.Add(text))
						{
							stringBuilder.Append(text);
						}
					}
					else if (hashSet.Add(requerimiento.mensajesDeRequerimiento.positivo))
					{
						stringBuilder.Append(requerimiento.mensajesDeRequerimiento.positivo);
					}
				}
				hashSet.Clear();
				for (int i = 0; i < respuesta.bonusesActivados.Count; i++)
				{
					AgenciasHelper.BonusRespuesta bonusRespuesta = respuesta.bonusesActivados[i];
					if (!bonusRespuesta.estaDesblokeado)
					{
						Agencia.MensajesDeRequerimientoSingle postMensajesAlDesblokear = bonusRespuesta.bonus.postMensajesAlDesblokear;
						if (string.IsNullOrWhiteSpace((postMensajesAlDesblokear != null) ? postMensajesAlDesblokear.msg : null))
						{
							string text2 = OtrasAgencias.GetMsgDeRequerimientoV2(bonusRespuesta.bonus).ToString();
							text2 = string.Format(this.m_BonusesPorDefecto.adicionalAlDesblokear.positivo, text2);
							if (hashSet.Add(text2))
							{
								stringBuilder.Append('\n');
								stringBuilder.Append(text2);
							}
						}
						else if (hashSet.Add(bonusRespuesta.bonus.postMensajesAlDesblokear.msg))
						{
							stringBuilder.Append('\n');
							stringBuilder.Append(bonusRespuesta.bonus.postMensajesAlDesblokear.msg);
						}
					}
				}
				hashSet.Clear();
				for (int j = 0; j < respuesta.antiBonusesActivados.Count; j++)
				{
					AgenciasHelper.BonusRespuesta bonusRespuesta2 = respuesta.antiBonusesActivados[j];
					if (!bonusRespuesta2.estaDesblokeado)
					{
						Agencia.MensajesDeRequerimientoSingle postMensajesAlDesblokear2 = bonusRespuesta2.bonus.postMensajesAlDesblokear;
						if (string.IsNullOrWhiteSpace((postMensajesAlDesblokear2 != null) ? postMensajesAlDesblokear2.msg : null))
						{
							string text3 = OtrasAgencias.GetMsgDeRequerimientoV2(bonusRespuesta2.bonus).ToString();
							text3 = string.Format(this.m_BonusesPorDefecto.adicionalAlDesblokear.negativo, text3);
							if (hashSet.Add(text3))
							{
								stringBuilder.Append('\n');
								stringBuilder.Append(text3);
							}
						}
						else if (hashSet.Add(bonusRespuesta2.bonus.postMensajesAlDesblokear.msg))
						{
							stringBuilder.Append('\n');
							stringBuilder.Append(bonusRespuesta2.bonus.postMensajesAlDesblokear.msg);
						}
					}
				}
				hashSet.Clear();
				for (int k = 0; k < respuesta.bonusesActivados.Count; k++)
				{
					AgenciasHelper.BonusRespuesta bonusRespuesta3 = respuesta.bonusesActivados[k];
					if (bonusRespuesta3.estaDesblokeado)
					{
						Agencia.MensajesDeRequerimientoSingle postMensajesDeBonus = bonusRespuesta3.bonus.postMensajesDeBonus;
						if (string.IsNullOrWhiteSpace((postMensajesDeBonus != null) ? postMensajesDeBonus.msg : null))
						{
							string text4 = OtrasAgencias.GetMsgDeRequerimientoV2(bonusRespuesta3.bonus).ToString();
							text4 = string.Format(this.m_BonusesPorDefecto.conBonuses.positivo, text4);
							if (hashSet.Add(text4))
							{
								stringBuilder.Append('\n');
								stringBuilder.Append(text4);
							}
						}
						else if (hashSet.Add(bonusRespuesta3.bonus.postMensajesDeBonus.msg))
						{
							stringBuilder.Append('\n');
							stringBuilder.Append(bonusRespuesta3.bonus.postMensajesDeBonus.msg);
						}
					}
				}
				hashSet.Clear();
				for (int l = 0; l < respuesta.antiBonusesActivados.Count; l++)
				{
					AgenciasHelper.BonusRespuesta bonusRespuesta4 = respuesta.antiBonusesActivados[l];
					if (!bonusRespuesta4.estaDesblokeado)
					{
						Agencia.MensajesDeRequerimientoSingle postMensajesDeBonus2 = bonusRespuesta4.bonus.postMensajesDeBonus;
						if (string.IsNullOrWhiteSpace((postMensajesDeBonus2 != null) ? postMensajesDeBonus2.msg : null))
						{
							string text5 = OtrasAgencias.GetMsgDeRequerimientoV2(bonusRespuesta4.bonus).ToString();
							text5 = string.Format(this.m_BonusesPorDefecto.conBonuses.negativo, text5);
							if (hashSet.Add(text5))
							{
								stringBuilder.Append('\n');
								stringBuilder.Append(text5);
							}
						}
						else if (hashSet.Add(bonusRespuesta4.bonus.postMensajesDeBonus.msg))
						{
							stringBuilder.Append('\n');
							stringBuilder.Append(bonusRespuesta4.bonus.postMensajesDeBonus.msg);
						}
					}
				}
				hashSet.Clear();
				stringBuilder.Append('\n');
				Agencia.MensajesDeRequerimiento final = agencia.mensajes.final;
				if (string.IsNullOrWhiteSpace((final != null) ? final.positivo : null))
				{
					stringBuilder.Append(string.Format(this.m_FinalesPorDefecto.final.positivo, agencia.nombre));
				}
				else
				{
					stringBuilder.Append(string.Format(agencia.mensajes.final.positivo, agencia.nombre));
				}
			}
			else
			{
				Agencia.MensajesDeRequerimiento inicio2 = agencia.mensajes.inicio;
				if (string.IsNullOrWhiteSpace((inicio2 != null) ? inicio2.negativo : null))
				{
					stringBuilder.Append(string.Format(this.m_IniciosPorDefecto.inicio.negativo, character.nombreCompleto));
				}
				else
				{
					stringBuilder.Append(string.Format(agencia.mensajes.inicio.negativo, character.nombreCompleto));
				}
				hashSet.Clear();
				for (int m = 0; m < agencia.requerimientos.Count; m++)
				{
					Agencia.Requerimiento agenciaReq = agencia.requerimientos[m];
					if (respuesta.requerimientosActivados.FirstOrDefault((Agencia.Requerimiento req) => req.rutaV2 == agenciaReq.rutaV2) == null)
					{
						Agencia.MensajesDeRequerimiento mensajesDeRequerimiento2 = agenciaReq.mensajesDeRequerimiento;
						if (string.IsNullOrWhiteSpace((mensajesDeRequerimiento2 != null) ? mensajesDeRequerimiento2.negativo : null))
						{
							string text6 = OtrasAgencias.GetMsgDeRequerimientoV2(agenciaReq).ToString();
							text6 = string.Format(this.m_CuerposPorDefecto.cuerpo.negativo, text6);
							if (hashSet.Add(text6))
							{
								stringBuilder.Append('\n');
								stringBuilder.Append(text6);
							}
						}
						else if (hashSet.Add(agenciaReq.mensajesDeRequerimiento.negativo))
						{
							stringBuilder.Append('\n');
							stringBuilder.Append(agenciaReq.mensajesDeRequerimiento.negativo);
						}
					}
				}
				hashSet.Clear();
				Agencia.AntiRequerimiento antiRequerimiento = respuesta.antiRequerimientosActivados.RandomItemReadOnly<Agencia.AntiRequerimiento>();
				if (antiRequerimiento != null)
				{
					Agencia.MensajesDeRequerimientoSingle mensajesDeRequerimiento3 = antiRequerimiento.mensajesDeRequerimiento;
					if (string.IsNullOrWhiteSpace((mensajesDeRequerimiento3 != null) ? mensajesDeRequerimiento3.msg : null))
					{
						string text7 = OtrasAgencias.GetMsgDeRequerimientoV2(antiRequerimiento).ToString();
						text7 = string.Format(this.m_CuerposPorDefecto.cuerpoAntiRequerimientos.msg, text7);
						if (hashSet.Add(text7))
						{
							stringBuilder.Append('\n');
							stringBuilder.Append(text7);
						}
					}
					else if (hashSet.Add(antiRequerimiento.mensajesDeRequerimiento.msg))
					{
						stringBuilder.Append('\n');
						stringBuilder.Append(antiRequerimiento.mensajesDeRequerimiento.msg);
					}
				}
				hashSet.Clear();
				stringBuilder.Append('\n');
				Agencia.MensajesDeRequerimiento final2 = agencia.mensajes.final;
				if (string.IsNullOrWhiteSpace((final2 != null) ? final2.negativo : null))
				{
					stringBuilder.Append(string.Format(this.m_FinalesPorDefecto.final.negativo, agencia.nombre));
				}
				else
				{
					stringBuilder.Append(string.Format(agencia.mensajes.final.negativo, agencia.nombre));
				}
			}
			return stringBuilder.ToString();
		}

		// Token: 0x0600079C RID: 1948 RVA: 0x0002BA5D File Offset: 0x00029C5D
		public override SingletonEditorBotones Boton3()
		{
			return new SingletonEditorBotones
			{
				text = "Print Agencia Mensajes"
			};
		}

		// Token: 0x0600079D RID: 1949 RVA: 0x0002BA70 File Offset: 0x00029C70
		public override void Aplicar3()
		{
			base.Aplicar3();
			foreach (Agencia agencia in this.m_agencias)
			{
				MonoBehaviour.print("AGENCIA -> " + agencia.ID);
				string text = string.Empty;
				text = text + agencia.nombre + ":\n";
				text = text + string.Format(this.m_IniciosPorDefecto.inicio.positivo, "[Nombre Modelo Here]") + " ";
				if (agencia.requerimientos.Count == 0)
				{
					text += this.m_CuerposPorDefecto.cuerpoSinRequerimientos.msg;
					text += "\n";
				}
				else
				{
					foreach (Agencia.Requerimiento requerimiento in agencia.requerimientos)
					{
						Agencia.MensajesDeRequerimiento mensajesDeRequerimiento = requerimiento.mensajesDeRequerimiento;
						if (string.IsNullOrWhiteSpace((mensajesDeRequerimiento != null) ? mensajesDeRequerimiento.positivo : null))
						{
							string text2 = OtrasAgencias.GetMsgDeRequerimientoV2(requerimiento).ToString();
							text += string.Format(this.m_CuerposPorDefecto.cuerpo.positivo, text2);
						}
						else
						{
							text += requerimiento.mensajesDeRequerimiento.positivo;
						}
						text += "\n";
					}
				}
				foreach (Agencia.Bonus bonus in agencia.bonuses)
				{
					Agencia.MensajesDeRequerimientoSingle postMensajesAlDesblokear = bonus.postMensajesAlDesblokear;
					if (string.IsNullOrWhiteSpace((postMensajesAlDesblokear != null) ? postMensajesAlDesblokear.msg : null))
					{
						string text3 = OtrasAgencias.GetMsgDeRequerimientoV2(bonus).ToString();
						text += string.Format(this.m_BonusesPorDefecto.adicionalAlDesblokear.positivo, text3);
					}
					else
					{
						text += bonus.postMensajesAlDesblokear.msg;
					}
					text += "\n";
				}
				foreach (Agencia.Bonus bonus2 in agencia.antiBonuses)
				{
					Agencia.MensajesDeRequerimientoSingle postMensajesAlDesblokear2 = bonus2.postMensajesAlDesblokear;
					if (string.IsNullOrWhiteSpace((postMensajesAlDesblokear2 != null) ? postMensajesAlDesblokear2.msg : null))
					{
						string text4 = OtrasAgencias.GetMsgDeRequerimientoV2(bonus2).ToString();
						text += string.Format(this.m_BonusesPorDefecto.adicionalAlDesblokear.negativo, text4);
					}
					else
					{
						text += bonus2.postMensajesAlDesblokear.msg;
					}
					text += "\n";
				}
				foreach (Agencia.Bonus bonus3 in agencia.bonuses)
				{
					Agencia.MensajesDeRequerimientoSingle postMensajesDeBonus = bonus3.postMensajesDeBonus;
					if (string.IsNullOrWhiteSpace((postMensajesDeBonus != null) ? postMensajesDeBonus.msg : null))
					{
						string text5 = OtrasAgencias.GetMsgDeRequerimientoV2(bonus3).ToString();
						text += string.Format(this.m_BonusesPorDefecto.conBonuses.positivo, text5);
					}
					else
					{
						text += bonus3.postMensajesDeBonus.msg;
					}
					text += "\n";
				}
				foreach (Agencia.Bonus bonus4 in agencia.antiBonuses)
				{
					Agencia.MensajesDeRequerimientoSingle postMensajesDeBonus2 = bonus4.postMensajesDeBonus;
					if (string.IsNullOrWhiteSpace((postMensajesDeBonus2 != null) ? postMensajesDeBonus2.msg : null))
					{
						string text6 = OtrasAgencias.GetMsgDeRequerimientoV2(bonus4).ToString();
						text += string.Format(this.m_BonusesPorDefecto.conBonuses.negativo, text6);
					}
					else
					{
						text += bonus4.postMensajesDeBonus.msg;
					}
					text += "\n";
				}
				text += string.Format(this.m_FinalesPorDefecto.final.positivo, agencia.nombre);
				MonoBehaviour.print(text);
				MonoBehaviour.print("TODO Negativos");
			}
		}

		// Token: 0x04000453 RID: 1107
		[SerializeField]
		private List<Agencia> m_agencias = new List<Agencia>();

		// Token: 0x04000454 RID: 1108
		[SerializeField]
		private OtrasAgencias.IniciosMsg m_IniciosPorDefecto = new OtrasAgencias.IniciosMsg();

		// Token: 0x04000455 RID: 1109
		[SerializeField]
		private OtrasAgencias.CuerposMsg m_CuerposPorDefecto = new OtrasAgencias.CuerposMsg();

		// Token: 0x04000456 RID: 1110
		[SerializeField]
		private OtrasAgencias.BonusesMsg m_BonusesPorDefecto = new OtrasAgencias.BonusesMsg();

		// Token: 0x04000457 RID: 1111
		[SerializeField]
		private OtrasAgencias.FinalesMsg m_FinalesPorDefecto = new OtrasAgencias.FinalesMsg();

		// Token: 0x04000458 RID: 1112
		[SerializeField]
		private OtrasAgencias.IncomeChangeBuffAndDebuff m_IncomeChangeBuffAndDebuff = new OtrasAgencias.IncomeChangeBuffAndDebuff();

		// Token: 0x04000459 RID: 1113
		[NonSerialized]
		private Dictionary<string, Agencia> m_agenciasDeId = new Dictionary<string, Agencia>();

		// Token: 0x0400045A RID: 1114
		private static List<MemberInfo> m_acendenciaTemp = new List<MemberInfo>();

		// Token: 0x0200025B RID: 603
		[Serializable]
		public class IncomeChangeBuffAndDebuff
		{
			// Token: 0x04000B3F RID: 2879
			[StringSelectorV2(typeof(ProveedorBuffIdsAttribute))]
			public string smallIncrease;

			// Token: 0x04000B40 RID: 2880
			[StringSelectorV2(typeof(ProveedorBuffIdsAttribute))]
			public string smallDecrease;

			// Token: 0x04000B41 RID: 2881
			[StringSelectorV2(typeof(ProveedorBuffIdsAttribute))]
			public string increase;

			// Token: 0x04000B42 RID: 2882
			[StringSelectorV2(typeof(ProveedorBuffIdsAttribute))]
			public string decrease;
		}

		// Token: 0x0200025C RID: 604
		[Serializable]
		public class IniciosMsg
		{
			// Token: 0x04000B43 RID: 2883
			public Agencia.MensajesDeRequerimiento inicio = new Agencia.MensajesDeRequerimiento();
		}

		// Token: 0x0200025D RID: 605
		[Serializable]
		public class CuerposMsg
		{
			// Token: 0x04000B44 RID: 2884
			public Agencia.MensajesDeRequerimiento cuerpo = new Agencia.MensajesDeRequerimiento();

			// Token: 0x04000B45 RID: 2885
			public Agencia.MensajesDeRequerimientoSingle cuerpoAntiRequerimientos = new Agencia.MensajesDeRequerimientoSingle();

			// Token: 0x04000B46 RID: 2886
			public Agencia.MensajesDeRequerimientoSingle cuerpoSinRequerimientos = new Agencia.MensajesDeRequerimientoSingle();

			// Token: 0x04000B47 RID: 2887
			public Agencia.MensajesDeRequerimientoSingle cuerpoNoAsistio = new Agencia.MensajesDeRequerimientoSingle();

			// Token: 0x04000B48 RID: 2888
			public Agencia.MensajesDeRequerimientoSingle cuerpoUnlocked = new Agencia.MensajesDeRequerimientoSingle();
		}

		// Token: 0x0200025E RID: 606
		[Serializable]
		public class BonusesMsg
		{
			// Token: 0x04000B49 RID: 2889
			public Agencia.MensajesDeRequerimiento conBonuses = new Agencia.MensajesDeRequerimiento();

			// Token: 0x04000B4A RID: 2890
			public Agencia.MensajesDeRequerimiento adicionalAlDesblokear = new Agencia.MensajesDeRequerimiento();
		}

		// Token: 0x0200025F RID: 607
		[Serializable]
		public class FinalesMsg
		{
			// Token: 0x04000B4B RID: 2891
			public Agencia.MensajesDeRequerimiento final = new Agencia.MensajesDeRequerimiento();
		}
	}
}
