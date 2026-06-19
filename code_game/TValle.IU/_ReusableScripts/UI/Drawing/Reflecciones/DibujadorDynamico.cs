using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Runtime.CompilerServices;
using Assets.Base.Plugins.Runtime.UI;
using Assets.SingletonesAndSystemasGlobales.AbstractLayer.Globales;
using Assets.TValle.IU.Runtime.Drawing;
using Assets.TValle.IU.Runtime.Drawing.Elementos;
using Assets.TValle.IU.Runtime.Drawing.Elementos.AutoRatingProfilesDeGrupos;
using Assets.TValle.IU.Runtime.Drawing.Elementos.Paneles;
using Assets.TValle.IU.Runtime.Drawing.Elementos.Paneles.Abstracts;
using Assets.TValle.Tools.Runtime;
using Assets.TValle.Tools.Runtime.UI;
using Assets._ReusableScripts.Globales.Mapas;
using Assets._ReusableScripts.UI.Drawing.Elementos;
using Assets._ReusableScripts.UI.Drawing.Elementos.Abstracts;
using Assets._ReusableScripts.UI.Drawing.Elementos.Modales;
using TMPro;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

namespace Assets._ReusableScripts.UI.Drawing.Reflecciones
{
	// Token: 0x02000086 RID: 134
	public class DibujadorDynamico
	{
		// Token: 0x17000143 RID: 323
		// (get) Token: 0x06000382 RID: 898 RVA: 0x00007CA6 File Offset: 0x00005EA6
		public static DibujadorDynamico instance
		{
			get
			{
				if (DibujadorDynamico.m_instance == null)
				{
					DibujadorDynamico.m_instance = new DibujadorDynamico();
				}
				return DibujadorDynamico.m_instance;
			}
		}

		// Token: 0x06000383 RID: 899 RVA: 0x00007CC0 File Offset: 0x00005EC0
		private T_Buscando GetAttribute<T_Buscando>(IEnumerable<Attribute> atributes) where T_Buscando : class
		{
			if (atributes == null)
			{
				return default(T_Buscando);
			}
			foreach (Attribute attribute in atributes)
			{
				T_Buscando t_Buscando = attribute as T_Buscando;
				if (t_Buscando != null)
				{
					return t_Buscando;
				}
			}
			return default(T_Buscando);
		}

		// Token: 0x06000384 RID: 900 RVA: 0x00007D30 File Offset: 0x00005F30
		private T_Buscando TryGetAttributeAt<T_Buscando>(IEnumerable<Attribute> atributes, int index) where T_Buscando : class
		{
			if (atributes == null)
			{
				return default(T_Buscando);
			}
			IEnumerable<Attribute> enumerable = atributes.Where((Attribute i) => i is T_Buscando);
			int num = enumerable.Count<Attribute>();
			if (num == 0 || index < 0)
			{
				return default(T_Buscando);
			}
			int num2 = index % num;
			T_Buscando t_Buscando;
			try
			{
				t_Buscando = enumerable.ElementAt(num2) as T_Buscando;
			}
			catch (Exception ex)
			{
				throw ex;
			}
			return t_Buscando;
		}

		// Token: 0x06000385 RID: 901 RVA: 0x00007DB4 File Offset: 0x00005FB4
		private T_Buscando TryGetAttributeFirst<T_Buscando>(IEnumerable<Attribute> atributes) where T_Buscando : class
		{
			if (atributes == null)
			{
				return default(T_Buscando);
			}
			return atributes.Where((Attribute i) => i is T_Buscando).FirstOrDefault<Attribute>() as T_Buscando;
		}

		// Token: 0x06000386 RID: 902 RVA: 0x00007E04 File Offset: 0x00006004
		private T_Buscando TryGetAttributeLast<T_Buscando>(IEnumerable<Attribute> atributes) where T_Buscando : class
		{
			if (atributes == null)
			{
				return default(T_Buscando);
			}
			IEnumerable<Attribute> enumerable = atributes.Where((Attribute i) => i is T_Buscando);
			int num = enumerable.Count<Attribute>();
			if (num == 0)
			{
				return default(T_Buscando);
			}
			int num2 = (num - 1) % num;
			T_Buscando t_Buscando;
			try
			{
				t_Buscando = enumerable.ElementAt(num2) as T_Buscando;
			}
			catch (Exception ex)
			{
				throw ex;
			}
			return t_Buscando;
		}

		// Token: 0x06000387 RID: 903 RVA: 0x00007E88 File Offset: 0x00006088
		private IList<TextoLocalizadoAttribute> GetCurrentLocalizationsOrDefault<T_Buscando>(IEnumerable<Attribute> atributes, string defaultText, string defaultLocal) where T_Buscando : TextoLocalizadoAttribute, new()
		{
			IList<TextoLocalizadoAttribute> list2;
			try
			{
				List<TextoLocalizadoAttribute> list = new List<TextoLocalizadoAttribute>();
				foreach (Attribute attribute in atributes)
				{
					if (attribute is T_Buscando)
					{
						this.m_TempTEXTLOCAL.Add((T_Buscando)((object)attribute));
					}
				}
				if (this.m_TempTEXTLOCAL.Count == 0)
				{
					T_Buscando t_Buscando = new T_Buscando();
					t_Buscando.text = defaultText;
					t_Buscando.localizationID = defaultLocal;
					list.Add(t_Buscando);
					list2 = list;
				}
				else if (this.m_TempTEXTLOCAL.Count == 1)
				{
					list.Add(this.m_TempTEXTLOCAL[0]);
					list2 = list;
				}
				else
				{
					string cultura = Singleton<ConfiguracionGeneralDeIdioma>.instance.idioma.cultura;
					foreach (TextoLocalizadoAttribute textoLocalizadoAttribute in this.m_TempTEXTLOCAL)
					{
						if (string.Equals(cultura, textoLocalizadoAttribute.localizationID, StringComparison.InvariantCultureIgnoreCase))
						{
							list.Add(textoLocalizadoAttribute);
						}
					}
					if (list.Count == 0)
					{
						T_Buscando t_Buscando2 = new T_Buscando();
						t_Buscando2.text = defaultText;
						t_Buscando2.localizationID = defaultLocal;
						list.Add(t_Buscando2);
						list2 = list;
					}
					else
					{
						list2 = list;
					}
				}
			}
			finally
			{
				this.m_TempTEXTLOCAL.Clear();
			}
			return list2;
		}

		// Token: 0x06000388 RID: 904 RVA: 0x0000803C File Offset: 0x0000623C
		private IList<TextoLocalizadoAttribute> GetCurrentLocalizations<T_Buscando>(IEnumerable<Attribute> atributes) where T_Buscando : TextoLocalizadoAttribute
		{
			IList<TextoLocalizadoAttribute> list2;
			try
			{
				List<TextoLocalizadoAttribute> list = new List<TextoLocalizadoAttribute>();
				foreach (Attribute attribute in atributes)
				{
					if (attribute is T_Buscando)
					{
						this.m_TempTEXTLOCAL.Add((T_Buscando)((object)attribute));
					}
				}
				if (this.m_TempTEXTLOCAL.Count == 0)
				{
					list2 = null;
				}
				else if (this.m_TempTEXTLOCAL.Count == 1)
				{
					list.Add(this.m_TempTEXTLOCAL[0]);
					list2 = list;
				}
				else
				{
					string cultura = Singleton<ConfiguracionGeneralDeIdioma>.instance.idioma.cultura;
					foreach (TextoLocalizadoAttribute textoLocalizadoAttribute in this.m_TempTEXTLOCAL)
					{
						if (string.Equals(cultura, textoLocalizadoAttribute.localizationID, StringComparison.InvariantCultureIgnoreCase))
						{
							list.Add(textoLocalizadoAttribute);
						}
					}
					if (list.Count == 0)
					{
						list2 = null;
					}
					else
					{
						list2 = list;
					}
				}
			}
			finally
			{
				this.m_TempTEXTLOCAL.Clear();
			}
			return list2;
		}

		// Token: 0x06000389 RID: 905 RVA: 0x0000816C File Offset: 0x0000636C
		private IList<TextoLocalizadoAttribute> GetCurrentLocalizationsOrDefault<T_Buscando>(MemberInfo fieldInfo, string defaultText, string defaultLocal) where T_Buscando : TextoLocalizadoAttribute, new()
		{
			return this.GetCurrentLocalizationsOrDefault<T_Buscando>(fieldInfo.GetCustomAttributes(), defaultText, defaultLocal);
		}

		// Token: 0x0600038A RID: 906 RVA: 0x0000817C File Offset: 0x0000637C
		private IList<TextoLocalizadoAttribute> GetCurrentLocalizations<T_Buscando>(MemberInfo fieldInfo) where T_Buscando : TextoLocalizadoAttribute
		{
			return this.GetCurrentLocalizations<T_Buscando>(fieldInfo.GetCustomAttributes());
		}

		// Token: 0x0600038B RID: 907 RVA: 0x0000818C File Offset: 0x0000638C
		private TextoLocalizadoAttribute GetCurrentLocalizationOrDefault<T_Buscando>(IEnumerable<Attribute> atributes, string defaultText, string defaultLocal) where T_Buscando : TextoLocalizadoAttribute, new()
		{
			TextoLocalizadoAttribute textoLocalizadoAttribute;
			try
			{
				foreach (Attribute attribute in atributes)
				{
					if (attribute is T_Buscando)
					{
						this.m_TempTEXTLOCAL.Add((T_Buscando)((object)attribute));
					}
				}
				if (this.m_TempTEXTLOCAL.Count == 0)
				{
					T_Buscando t_Buscando = new T_Buscando();
					t_Buscando.text = defaultText;
					t_Buscando.localizationID = defaultLocal;
					textoLocalizadoAttribute = t_Buscando;
				}
				else if (this.m_TempTEXTLOCAL.Count == 1)
				{
					textoLocalizadoAttribute = this.m_TempTEXTLOCAL[0];
				}
				else
				{
					string cultura = Singleton<ConfiguracionGeneralDeIdioma>.instance.idioma.cultura;
					foreach (TextoLocalizadoAttribute textoLocalizadoAttribute2 in this.m_TempTEXTLOCAL)
					{
						if (string.Equals(cultura, textoLocalizadoAttribute2.localizationID, StringComparison.InvariantCultureIgnoreCase))
						{
							return textoLocalizadoAttribute2;
						}
					}
					textoLocalizadoAttribute = this.m_TempTEXTLOCAL[0];
				}
			}
			finally
			{
				this.m_TempTEXTLOCAL.Clear();
			}
			return textoLocalizadoAttribute;
		}

		// Token: 0x0600038C RID: 908 RVA: 0x000082C8 File Offset: 0x000064C8
		public string GetCurrentLabelOrDefaul<T_Buscando>(Type type) where T_Buscando : TextoLocalizadoAttribute
		{
			TextoLocalizadoAttribute currentLocalization = this.GetCurrentLocalization<T_Buscando>(type);
			if (currentLocalization == null)
			{
				return type.Name;
			}
			return currentLocalization.text;
		}

		// Token: 0x0600038D RID: 909 RVA: 0x000082F0 File Offset: 0x000064F0
		public TextoLocalizadoAttribute GetCurrentLocalization<T_Buscando>(Type type) where T_Buscando : TextoLocalizadoAttribute
		{
			IEnumerable<T_Buscando> customAttributes = type.GetCustomAttributes<T_Buscando>();
			return this.GetCurrentLocalization<T_Buscando>(customAttributes);
		}

		// Token: 0x0600038E RID: 910 RVA: 0x0000830C File Offset: 0x0000650C
		private TextoLocalizadoAttribute GetCurrentLocalization<T_Buscando>(IEnumerable<Attribute> atributes) where T_Buscando : TextoLocalizadoAttribute
		{
			TextoLocalizadoAttribute textoLocalizadoAttribute;
			try
			{
				foreach (Attribute attribute in atributes)
				{
					if (attribute is T_Buscando)
					{
						this.m_TempTEXTLOCAL.Add((T_Buscando)((object)attribute));
					}
				}
				if (this.m_TempTEXTLOCAL.Count == 0)
				{
					textoLocalizadoAttribute = null;
				}
				else if (this.m_TempTEXTLOCAL.Count == 1)
				{
					textoLocalizadoAttribute = this.m_TempTEXTLOCAL[0];
				}
				else
				{
					string cultura = Singleton<ConfiguracionGeneralDeIdioma>.instance.idioma.cultura;
					foreach (TextoLocalizadoAttribute textoLocalizadoAttribute2 in this.m_TempTEXTLOCAL)
					{
						if (string.Equals(cultura, textoLocalizadoAttribute2.localizationID, StringComparison.InvariantCultureIgnoreCase))
						{
							return textoLocalizadoAttribute2;
						}
					}
					textoLocalizadoAttribute = this.m_TempTEXTLOCAL[0];
				}
			}
			finally
			{
				this.m_TempTEXTLOCAL.Clear();
			}
			return textoLocalizadoAttribute;
		}

		// Token: 0x0600038F RID: 911 RVA: 0x00008428 File Offset: 0x00006628
		public TextoLocalizadoAttribute GetCurrentLocalization<T_Buscando>(MemberInfo fieldInfo) where T_Buscando : TextoLocalizadoAttribute
		{
			return this.GetCurrentLocalization<T_Buscando>(fieldInfo.GetCustomAttributes());
		}

		// Token: 0x06000390 RID: 912 RVA: 0x00008436 File Offset: 0x00006636
		private TextoLocalizadoAttribute GetCurrentLocalizationOrDefault<T_Buscando>(MemberInfo fieldInfo, string defaultText, string defaultLocal) where T_Buscando : TextoLocalizadoAttribute, new()
		{
			return this.GetCurrentLocalizationOrDefault<T_Buscando>(fieldInfo.GetCustomAttributes(), defaultText, defaultLocal);
		}

		// Token: 0x06000391 RID: 913 RVA: 0x00008448 File Offset: 0x00006648
		private TValleUILocalTextAttribute GetCurrentLocalizationModding<T_Buscando>(IEnumerable<Attribute> atributes) where T_Buscando : TValleUILocalTextAttribute
		{
			TValleUILocalTextAttribute tvalleUILocalTextAttribute;
			try
			{
				foreach (Attribute attribute in atributes)
				{
					if (attribute is T_Buscando)
					{
						this.m_TempTEXTLOCAL_Modding.Add((T_Buscando)((object)attribute));
					}
				}
				if (this.m_TempTEXTLOCAL_Modding.Count == 0)
				{
					tvalleUILocalTextAttribute = null;
				}
				else if (this.m_TempTEXTLOCAL_Modding.Count == 1)
				{
					tvalleUILocalTextAttribute = this.m_TempTEXTLOCAL_Modding[0];
				}
				else
				{
					Language language = this.ParseLocal(Singleton<ConfiguracionGeneralDeIdioma>.instance.idioma.id);
					foreach (TValleUILocalTextAttribute tvalleUILocalTextAttribute2 in this.m_TempTEXTLOCAL_Modding)
					{
						if (language == tvalleUILocalTextAttribute2.localizationID)
						{
							return tvalleUILocalTextAttribute2;
						}
					}
					tvalleUILocalTextAttribute = this.m_TempTEXTLOCAL_Modding[0];
				}
			}
			finally
			{
				this.m_TempTEXTLOCAL_Modding.Clear();
			}
			return tvalleUILocalTextAttribute;
		}

		// Token: 0x06000392 RID: 914 RVA: 0x00008564 File Offset: 0x00006764
		private IList<TValleUILocalTextAttribute> GetCurrentLocalizationsModding<T_Buscando>(IEnumerable<Attribute> atributes) where T_Buscando : TValleUILocalTextAttribute
		{
			IList<TValleUILocalTextAttribute> list2;
			try
			{
				List<TValleUILocalTextAttribute> list = new List<TValleUILocalTextAttribute>();
				foreach (Attribute attribute in atributes)
				{
					if (attribute is T_Buscando)
					{
						this.m_TempTEXTLOCAL_Modding.Add((T_Buscando)((object)attribute));
					}
				}
				if (this.m_TempTEXTLOCAL_Modding.Count == 0)
				{
					list2 = null;
				}
				else if (this.m_TempTEXTLOCAL_Modding.Count == 1)
				{
					list.Add(this.m_TempTEXTLOCAL_Modding[0]);
					list2 = list;
				}
				else
				{
					Language language = this.ParseLocal(Singleton<ConfiguracionGeneralDeIdioma>.instance.idioma.id);
					foreach (TValleUILocalTextAttribute tvalleUILocalTextAttribute in this.m_TempTEXTLOCAL_Modding)
					{
						if (language == tvalleUILocalTextAttribute.localizationID)
						{
							list.Add(tvalleUILocalTextAttribute);
						}
					}
					if (list.Count == 0)
					{
						list2 = null;
					}
					else
					{
						list2 = list;
					}
				}
			}
			finally
			{
				this.m_TempTEXTLOCAL_Modding.Clear();
			}
			return list2;
		}

		// Token: 0x06000393 RID: 915 RVA: 0x00008694 File Offset: 0x00006894
		private Language ParseLocal(Localizacion gameLocal)
		{
			switch (gameLocal)
			{
			case Localizacion.None:
				return Language.None;
			case Localizacion.US:
				return Language.en;
			case Localizacion.ES:
				throw new NotImplementedException();
			default:
				throw new ArgumentOutOfRangeException(gameLocal.ToString());
			}
		}

		// Token: 0x06000394 RID: 916 RVA: 0x000086C8 File Offset: 0x000068C8
		private IUIPanel InstanciarPanel(object model, FieldInfo fieldInfoInParentModel, int index, IEnumerable<Attribute> panelAtributes, DibujadorDynamico.ExtraData extraData, IUIPanel parentPanel)
		{
			PanelAttribute attribute = this.GetAttribute<PanelAttribute>(panelAtributes);
			TipoDePanel tipoDePanel = ((attribute != null) ? new TipoDePanel?(attribute.tipo) : null).GetValueOrDefault();
			if (tipoDePanel == TipoDePanel.None)
			{
				tipoDePanel = TipoDePanel.scrollableFlotante;
			}
			IUIPanel iuipanel;
			switch (tipoDePanel)
			{
			case TipoDePanel.scrollableFlotante:
				iuipanel = Object.Instantiate<ScrollablePanel>(MapaSingleton<MapaSingletonDeUIPrefabs>.instance.scrollablePanel);
				break;
			case TipoDePanel.nestedContainer:
				iuipanel = Object.Instantiate<NestedContainer>(MapaSingleton<MapaSingletonDeUIPrefabs>.instance.nestedContainer);
				break;
			case TipoDePanel.panel1by3:
				iuipanel = Object.Instantiate<Panel1by3>(MapaSingleton<MapaSingletonDeUIPrefabs>.instance.panel1by3);
				break;
			case TipoDePanel.scrollableDePortraits:
				iuipanel = Object.Instantiate<ScrollablePortraitPanel>(MapaSingleton<MapaSingletonDeUIPrefabs>.instance.scrollablePortraitPanel);
				break;
			case TipoDePanel.autoRatingPortraitEditor:
				iuipanel = Object.Instantiate<AutoRatingProfilesEditor>(MapaSingleton<MapaSingletonDeUIPrefabs>.instance.autoRatingProfilesEditor);
				break;
			case TipoDePanel.autoRatingProfilesDeGrupos:
				iuipanel = Object.Instantiate<AutoRatingProfilesDeGruposPanel>(MapaSingleton<MapaSingletonDeUIPrefabs>.instance.autoRatingProfilesDeGruposPanel);
				break;
			case TipoDePanel.scrollableDeInterpretationProfilePortraits:
				iuipanel = Object.Instantiate<ScrollableProfilePortraitPanel>(MapaSingleton<MapaSingletonDeUIPrefabs>.instance.scrollableProfilePortraitPanel);
				break;
			case TipoDePanel.hueContraintPanel:
				iuipanel = Object.Instantiate<PrimaryColorToggles>(MapaSingleton<MapaSingletonDeUIPrefabs>.instance.colorContainer);
				break;
			case TipoDePanel.scrollableDePosePortraits:
				iuipanel = Object.Instantiate<ScrollablePosePortraitPanel>(MapaSingleton<MapaSingletonDeUIPrefabs>.instance.scrollablePosePortraitPanel);
				break;
			case TipoDePanel.thanks:
				iuipanel = Object.Instantiate<ScrollablePanel>(MapaSingleton<MapaSingletonDeUIPrefabs>.instance.thanksPanel);
				break;
			case TipoDePanel.panel1by3Detalles:
				iuipanel = Object.Instantiate<Panel1by3>(MapaSingleton<MapaSingletonDeUIPrefabs>.instance.panel1by3Detalles);
				break;
			case TipoDePanel.scrollableFlotanteBuscable:
				iuipanel = Object.Instantiate<ScrollablePanelConBuscadorYFavoritos>(MapaSingleton<MapaSingletonDeUIPrefabs>.instance.scrollablePanelDeItemsConBuscador);
				break;
			case TipoDePanel.panel1by1:
				iuipanel = Object.Instantiate<Panel1by1>(MapaSingleton<MapaSingletonDeUIPrefabs>.instance.panel1by1);
				break;
			case TipoDePanel.nestedContainerConTitulo:
				iuipanel = Object.Instantiate<NestedContainerConTitulo>(MapaSingleton<MapaSingletonDeUIPrefabs>.instance.nestedContainerConTitulo);
				break;
			case TipoDePanel.scrollableDeOutfitPortraits:
				iuipanel = Object.Instantiate<ScrollableOutfitsPortraitPanel>(MapaSingleton<MapaSingletonDeUIPrefabs>.instance.scrollableOutfitPortraitPanel);
				break;
			case TipoDePanel.scrollableWorkingModelsPortraits:
				iuipanel = Object.Instantiate<ScrollableCurrentWorkingModelsPortraitPanel>(MapaSingleton<MapaSingletonDeUIPrefabs>.instance.scrollableWorkingModelsPortraitsPanel);
				break;
			case TipoDePanel.scrollableDeGesturePortraits:
				iuipanel = Object.Instantiate<ScrollableGesturePortraitPanel>(MapaSingleton<MapaSingletonDeUIPrefabs>.instance.scrollableGesturePortraitPanel);
				break;
			case TipoDePanel.scrollableDeMakeoverPortraits:
				iuipanel = Object.Instantiate<ScrollableMakeoverPortraitPanel>(MapaSingleton<MapaSingletonDeUIPrefabs>.instance.scrollableMakeoverPortraitPanel);
				break;
			case TipoDePanel.scrollableJobPortraits:
				iuipanel = Object.Instantiate<ScrollableJobPortraitPanel>(MapaSingleton<MapaSingletonDeUIPrefabs>.instance.scrollableJobPortraitPanel);
				break;
			case TipoDePanel.scrollableFlotanteBuscableDePortraits:
				iuipanel = Object.Instantiate<ScrollablePanelConBuscadorYFavoritos>(MapaSingleton<MapaSingletonDeUIPrefabs>.instance.scrollablePanelDePortraitsConBuscador);
				break;
			case TipoDePanel.objectivesPanel:
				iuipanel = Object.Instantiate<ScrollablePanel>(MapaSingleton<MapaSingletonDeUIPrefabs>.instance.objectivesPanel);
				break;
			case TipoDePanel.scrollableOfficePortraits:
				iuipanel = Object.Instantiate<ScrollableOfficePortraitPanel>(MapaSingleton<MapaSingletonDeUIPrefabs>.instance.scrollableOfficePortraitPanel);
				break;
			default:
				throw new ArgumentOutOfRangeException(tipoDePanel.ToString());
			}
			IPanelLayoutAttribute panelLayoutAttribute = null;
			PanelAttribute attribute2 = this.GetAttribute<PanelAttribute>(panelAtributes);
			if (attribute2 != null)
			{
				string panelLayoutDynamicMethodTarget = attribute2.panelLayoutDynamicMethodTarget;
				MethodInfo methodInfo = extraData.paraType.miembrosDiccV2.GetValueOrDefault(new ValueTuple<Type, string>(model.GetType(), panelLayoutDynamicMethodTarget), null) as MethodInfo;
				if (methodInfo != null)
				{
					if (methodInfo.GetParameters().Length != 0)
					{
						Debug.LogException(new NotSupportedException("metodo debe tener zero parametros. en metodo: " + methodInfo.Name + " de modelo: " + fieldInfoInParentModel.Name));
					}
					if (methodInfo.ReturnType != typeof(IPanelLayoutAttribute))
					{
						Debug.LogException(new NotSupportedException(string.Concat(new string[]
						{
							"Se necesita Return type tipo :",
							typeof(IPanelLayoutAttribute).Name,
							". en metodo: ",
							methodInfo.Name,
							" de modelo: ",
							fieldInfoInParentModel.Name
						})));
					}
					PanelLayoutDinamicaHandler panelLayoutDinamicaHandler;
					try
					{
						panelLayoutDinamicaHandler = (PanelLayoutDinamicaHandler)methodInfo.CreateDelegate(typeof(PanelLayoutDinamicaHandler), model);
					}
					catch (Exception ex)
					{
						Debug.LogException(new NotSupportedException(ex.Message, ex));
						panelLayoutDinamicaHandler = null;
					}
					if (panelLayoutDinamicaHandler != null)
					{
						panelLayoutAttribute = panelLayoutDinamicaHandler();
					}
				}
			}
			if (parentPanel != null)
			{
				this.addUIElementoAPanel(parentPanel, iuipanel, panelAtributes, panelLayoutAttribute, false);
			}
			this.setPanelAlyoutGroupAttributes(model, iuipanel, panelAtributes, extraData.paraType.miembrosV2, panelLayoutAttribute);
			this.setPanelAttributes(model, iuipanel, panelAtributes, extraData.paraType.miembrosV2);
			this.setSize(model, (UIElemento)iuipanel, panelAtributes, extraData.paraType.miembrosV2, panelLayoutAttribute);
			return iuipanel;
		}

		// Token: 0x06000395 RID: 917 RVA: 0x00008ACC File Offset: 0x00006CCC
		private IUIElemento dibujarUIElemento(IUIPanel panel, MemberInfo memberInfo, object modelOwner, IEnumerable<Attribute> attr, DibujadorDynamico.ExtraData extradata)
		{
			if (modelOwner == null || memberInfo == null)
			{
				return null;
			}
			attr = extradata.overrides.Concat(attr, modelOwner, memberInfo.Name, -1);
			SelfDrawingAttribute customAttribute = memberInfo.GetCustomAttribute<SelfDrawingAttribute>();
			Func<IUIPanel, IUIElemento> func;
			if (customAttribute != null && extradata.paraType.selfDrawingMetodo.TryGetValue(new ValueTuple<Type, string>(modelOwner.GetType(), customAttribute.metodo), out func) && func != null)
			{
				IUIElemento iuielemento = func(panel);
				if (customAttribute.setConfig)
				{
					this.PostDibujarElemento1(panel, (UIElemento)iuielemento, memberInfo, attr, modelOwner, -1, false, extradata);
					this.PostDibujarElemento2(panel, (UIElemento)iuielemento, memberInfo, attr, modelOwner, extradata);
				}
				return iuielemento;
			}
			DynamicUIElementAttribute customAttribute2 = memberInfo.GetCustomAttribute<DynamicUIElementAttribute>();
			if (customAttribute2 != null)
			{
				return this.InstanciarUIElemento(customAttribute2, panel, memberInfo, modelOwner, attr, extradata);
			}
			Type underlyingType = memberInfo.GetUnderlyingType();
			if (underlyingType.IsEnum)
			{
				return this.dibujarDesplegableConToolTip(panel, memberInfo, modelOwner, -1, attr, extradata);
			}
			if (memberInfo is FieldInfo && underlyingType == typeof(string))
			{
				return this.dibujarElementAny(panel, () => MapaSingleton<MapaSingletonDeUIPrefabs>.instance.label, memberInfo, modelOwner, -1, attr, extradata);
			}
			bool flag = memberInfo is MethodInfo;
			bool flag2 = attr.FirstOrDefault((Attribute att) => att is LabelAttribute) != null;
			bool flag3 = attr.FirstOrDefault((Attribute att) => att is DescriptionAttribute) != null;
			if (flag && flag2 && flag3)
			{
				return this.dibujarClickableDescriptableLabelModding(panel, memberInfo, modelOwner, -1, attr, extradata);
			}
			return null;
		}

		// Token: 0x06000396 RID: 918 RVA: 0x00008C68 File Offset: 0x00006E68
		private IUIElemento InstanciarUIElemento(DynamicUIElementAttribute dina, IUIPanel panel, MemberInfo memberInfo, object modelOwner, IEnumerable<Attribute> attr, DibujadorDynamico.ExtraData extradata)
		{
			IUIElemento iuielemento;
			switch (dina.tipo)
			{
			case UIElementoDinamico.texto:
				iuielemento = this.dibujarElementAny(panel, () => MapaSingleton<MapaSingletonDeUIPrefabs>.instance.label, memberInfo, modelOwner, -1, attr, extradata);
				break;
			case UIElementoDinamico.desplegable:
				iuielemento = this.dibujarDesplegable(panel, memberInfo, modelOwner, -1, attr, extradata);
				break;
			case UIElementoDinamico.deslizable:
				iuielemento = this.dibujarDeslizable(panel, memberInfo, modelOwner, -1, attr, extradata);
				break;
			case UIElementoDinamico.botonDePanel:
			case UIElementoDinamico.botonDePanelConfirmable:
				return null;
			case UIElementoDinamico.clickableLabelDescriptable:
				iuielemento = this.dibujarClickableDescriptableLabel(panel, memberInfo, modelOwner, -1, attr, extradata);
				break;
			case UIElementoDinamico.clickableLabel:
				iuielemento = this.dibujarClickableLabel(panel, memberInfo, modelOwner, -1, attr, extradata);
				break;
			case UIElementoDinamico.toggle:
				iuielemento = this.dibujaToggle(panel, memberInfo, modelOwner, -1, attr, extradata);
				break;
			case UIElementoDinamico.analogueCal:
				iuielemento = this.dibujarAnalogueCal(panel, memberInfo, modelOwner, -1, attr, extradata);
				break;
			case UIElementoDinamico.patreonPanelButton:
				iuielemento = this.dibujarElement<PatreonPanelButtonAttribute>(panel, () => MapaSingleton<MapaSingletonDeUIPrefabs>.instance.pareonPanelButton, memberInfo, modelOwner, -1, attr, extradata);
				break;
			case UIElementoDinamico.labelDescriptable:
				iuielemento = this.dibujarElement<GenericUIElementAttribute>(panel, () => MapaSingleton<MapaSingletonDeUIPrefabs>.instance.labelYDesciption, memberInfo, modelOwner, -1, attr, extradata);
				break;
			case UIElementoDinamico.hairTroubleshooting:
				iuielemento = this.dibujarElement<GenericUIElementAttribute>(panel, () => MapaSingleton<MapaSingletonDeUIPrefabs>.instance.hairTroubleshooting, memberInfo, modelOwner, -1, attr, extradata);
				break;
			case UIElementoDinamico.discordPanelButton:
				iuielemento = this.dibujarElement<DiscordPanelButtonAttribute>(panel, () => MapaSingleton<MapaSingletonDeUIPrefabs>.instance.discordPanelButton, memberInfo, modelOwner, -1, attr, extradata);
				break;
			case UIElementoDinamico.deslizableHelpBoton:
				iuielemento = this.dibujarDeslizableHelpButt(panel, memberInfo, modelOwner, -1, attr, extradata);
				break;
			case UIElementoDinamico.desplegableHelpBoton:
				iuielemento = this.dibujarDesplegableHelp(panel, memberInfo, modelOwner, -1, attr, extradata);
				break;
			case UIElementoDinamico.portrait:
				iuielemento = this.dibujarSelectablePortrait(panel, memberInfo, modelOwner, -1, attr, extradata);
				break;
			case UIElementoDinamico.interpretationProfilePortrait:
				iuielemento = this.dibujarSelectableProfilePortrait(panel, memberInfo, modelOwner, -1, attr, extradata);
				break;
			case UIElementoDinamico.desplegableCompacto:
				iuielemento = this.dibujarDesplegableCompacto(panel, memberInfo, modelOwner, -1, attr, extradata);
				break;
			case UIElementoDinamico.desplegableConToolTip:
				iuielemento = this.dibujarDesplegableConToolTip(panel, memberInfo, modelOwner, -1, attr, extradata);
				break;
			case UIElementoDinamico.colorToggle:
				iuielemento = this.dibujaColorToggle(panel, memberInfo, modelOwner, -1, attr, extradata);
				break;
			case UIElementoDinamico.deslizableConToolTip:
				iuielemento = this.dibujarDeslizableConToolTip(panel, memberInfo, modelOwner, -1, attr, extradata);
				break;
			case UIElementoDinamico.posePortrait:
				iuielemento = this.dibujarSelectablePosePortrait(panel, memberInfo, modelOwner, -1, attr, extradata);
				break;
			case UIElementoDinamico.clickableFavoritableLabel:
				iuielemento = this.dibujarClickableLabelFav(panel, memberInfo, modelOwner, -1, attr, extradata);
				break;
			case UIElementoDinamico.labelPar:
				iuielemento = this.dibujaLabelPar(panel, memberInfo, modelOwner, -1, attr, extradata);
				break;
			case UIElementoDinamico.clickableLabelDescriptableCompacto:
				iuielemento = this.dibujarClickableDescriptableLabelCompacto(panel, memberInfo, modelOwner, -1, attr, extradata);
				break;
			case UIElementoDinamico.outfitPortrait:
				iuielemento = this.dibujarSelectableOutfitPortrait(panel, memberInfo, modelOwner, -1, attr, extradata);
				break;
			case UIElementoDinamico.clickableLabelConValor:
				iuielemento = this.dibujarClickableLabelConValor(panel, memberInfo, modelOwner, -1, attr, extradata);
				break;
			case UIElementoDinamico.desplegableLabelCorto:
				iuielemento = this.dibujarDesplegableLabelCorto(panel, memberInfo, modelOwner, -1, attr, extradata);
				break;
			case UIElementoDinamico.deslizableLabelCorto:
				iuielemento = this.dibujarDeslizableLabelCorto(panel, memberInfo, modelOwner, -1, attr, extradata);
				break;
			case UIElementoDinamico.infoLabel:
				iuielemento = this.dibujaInfoLabel(panel, memberInfo, modelOwner, -1, attr, extradata);
				break;
			case UIElementoDinamico.imagen:
				iuielemento = this.dibujaImagen(panel, memberInfo, modelOwner, -1, attr, extradata);
				break;
			case UIElementoDinamico.workingModelPortrait:
				iuielemento = this.dibujarSelectableWorkingModelPortrait(panel, memberInfo, modelOwner, -1, attr, extradata);
				break;
			case UIElementoDinamico.inputConToolTip:
				iuielemento = this.dibujarInputToolTip(panel, memberInfo, modelOwner, -1, attr, extradata);
				break;
			case UIElementoDinamico.gesturePortrait:
				iuielemento = this.dibujarSelectableGesturePortrait(panel, memberInfo, modelOwner, -1, attr, extradata);
				break;
			case UIElementoDinamico.makeoverPortrait:
				iuielemento = this.dibujarSelectableMakeoverPortrait(panel, memberInfo, modelOwner, -1, attr, extradata);
				break;
			case UIElementoDinamico.gameplayObjective:
				iuielemento = this.dibujarGameplayObjective(panel, memberInfo, modelOwner, -1, attr, extradata);
				break;
			case UIElementoDinamico.jobPortrait:
				iuielemento = this.dibujarSelectableJobPortrait(panel, memberInfo, modelOwner, -1, attr, extradata);
				break;
			case UIElementoDinamico.favoritableGenericPortrait:
				iuielemento = this.dibujarSelectableFavoritableGenericPortrait(panel, memberInfo, modelOwner, -1, attr, extradata);
				break;
			case UIElementoDinamico.labelCortoLabelLargoPar:
				iuielemento = this.dibujaLabelCortoLabelLargoPar(panel, memberInfo, modelOwner, -1, attr, extradata);
				break;
			case UIElementoDinamico.levelLabelCorto:
				iuielemento = this.dibujaLabelCortoLevel(panel, memberInfo, modelOwner, -1, attr, extradata);
				break;
			case UIElementoDinamico.tittleLabel:
				iuielemento = this.dibujaTitleLabel(panel, memberInfo, modelOwner, -1, attr, extradata);
				break;
			case UIElementoDinamico.officePortrait:
				iuielemento = this.dibujarSelectableOfficePortrait(panel, memberInfo, modelOwner, -1, attr, extradata);
				break;
			default:
				throw new ArgumentOutOfRangeException(dina.tipo.ToString());
			}
			return iuielemento;
		}

		// Token: 0x06000397 RID: 919 RVA: 0x00009120 File Offset: 0x00007320
		private void dibujarUIElementos(IUIPanel panel, IList<IUIElemento> resultado, MemberInfo fieldInfo, object modelOwner, IEnumerable<Attribute> attr, DibujadorDynamico.ExtraData extradata)
		{
			if (modelOwner == null || fieldInfo == null)
			{
				return;
			}
			attr = extradata.overrides.Concat(attr, modelOwner, fieldInfo.Name, -1);
			SelfDrawingAttribute customAttribute = fieldInfo.GetCustomAttribute<SelfDrawingAttribute>();
			Func<IUIPanel, IList<IUIElemento>> func;
			if (customAttribute != null && extradata.paraType.selfDrawingListMetodo.TryGetValue(new ValueTuple<Type, string>(modelOwner.GetType(), customAttribute.metodo), out func) && func != null)
			{
				resultado = func(panel);
				if (customAttribute.setConfig)
				{
					resultado.ForEach(delegate(IUIElemento e, int i)
					{
						IEnumerable<Attribute> enumerable50 = extradata.overrides.Concat(attr, modelOwner, fieldInfo.Name, i);
						this.PostDibujarElemento1(panel, (UIElemento)e, fieldInfo, enumerable50, modelOwner, i, false, extradata);
						this.PostDibujarElemento2(panel, (UIElemento)e, fieldInfo, enumerable50, modelOwner, extradata);
					});
				}
				return;
			}
			DynamicUIElementAttribute customAttribute2 = fieldInfo.GetCustomAttribute<DynamicUIElementAttribute>();
			if (customAttribute2 == null)
			{
				return;
			}
			if (fieldInfo.GetCustomAttribute<AsyncDrawedAttribute>() != null)
			{
				IEnumerable enumerable = (fieldInfo as FieldInfo).GetValue(modelOwner) as IEnumerable;
				Coroutine coroutine;
				if (DibujadorDynamico.m_CoroutineDePedido.TryGetValue(modelOwner, out coroutine))
				{
					if (coroutine != null)
					{
						Singleton<ConfiguracionGeneralDeGraficos>.instance.StopCoroutine(coroutine);
					}
					DibujadorDynamico.m_CoroutineDePedido.Remove(modelOwner);
				}
				coroutine = Singleton<ConfiguracionGeneralDeGraficos>.instance.StartCoroutine(this.AsynDrawer(panel, enumerable, customAttribute2, fieldInfo, modelOwner, attr, extradata));
				DibujadorDynamico.m_CoroutineDePedido.Add(modelOwner, coroutine);
				return;
			}
			switch (customAttribute2.tipo)
			{
			case UIElementoDinamico.deslizable:
			{
				IEnumerable enumerable2 = (fieldInfo as FieldInfo).GetValue(modelOwner) as IEnumerable;
				int num = -1;
				using (IEnumerator enumerator = enumerable2.GetEnumerator())
				{
					while (enumerator.MoveNext())
					{
						object obj = enumerator.Current;
						num++;
						IEnumerable<Attribute> enumerable3 = extradata.overrides.Concat(attr, modelOwner, fieldInfo.Name, num);
						IUIElemento iuielemento = this.dibujarDeslizable(panel, fieldInfo, modelOwner, num, enumerable3, extradata);
						resultado.Add(iuielemento);
					}
					return;
				}
				break;
			}
			case UIElementoDinamico.botonDePanel:
			case UIElementoDinamico.toggle:
			case UIElementoDinamico.analogueCal:
			case UIElementoDinamico.patreonPanelButton:
			case UIElementoDinamico.labelDescriptable:
			case UIElementoDinamico.hairTroubleshooting:
			case UIElementoDinamico.botonDePanelConfirmable:
			case UIElementoDinamico.discordPanelButton:
			case UIElementoDinamico.deslizableHelpBoton:
			case UIElementoDinamico.desplegableHelpBoton:
			case UIElementoDinamico.desplegableCompacto:
			case UIElementoDinamico.desplegableConToolTip:
			case UIElementoDinamico.colorToggle:
			case UIElementoDinamico.desplegableLabelCorto:
			case UIElementoDinamico.infoLabel:
			case UIElementoDinamico.imagen:
				goto IL_12B5;
			case UIElementoDinamico.clickableLabelDescriptable:
				goto IL_10AB;
			case UIElementoDinamico.clickableLabel:
				goto IL_0C91;
			case UIElementoDinamico.portrait:
				goto IL_050C;
			case UIElementoDinamico.interpretationProfilePortrait:
				goto IL_0A84;
			case UIElementoDinamico.deslizableConToolTip:
				break;
			case UIElementoDinamico.posePortrait:
				goto IL_05BB;
			case UIElementoDinamico.clickableFavoritableLabel:
				goto IL_0DEF;
			case UIElementoDinamico.labelPar:
				goto IL_0E9E;
			case UIElementoDinamico.clickableLabelDescriptableCompacto:
				goto IL_115A;
			case UIElementoDinamico.outfitPortrait:
				goto IL_07C8;
			case UIElementoDinamico.clickableLabelConValor:
				goto IL_0D40;
			case UIElementoDinamico.deslizableLabelCorto:
				goto IL_03AE;
			case UIElementoDinamico.workingModelPortrait:
				goto IL_0926;
			case UIElementoDinamico.inputConToolTip:
				goto IL_045D;
			case UIElementoDinamico.gesturePortrait:
				goto IL_066A;
			case UIElementoDinamico.makeoverPortrait:
				goto IL_0719;
			case UIElementoDinamico.gameplayObjective:
				goto IL_0877;
			case UIElementoDinamico.jobPortrait:
				goto IL_0B33;
			case UIElementoDinamico.favoritableGenericPortrait:
				goto IL_09D5;
			case UIElementoDinamico.labelCortoLabelLargoPar:
				goto IL_0F4D;
			case UIElementoDinamico.levelLabelCorto:
				goto IL_0FFC;
			case UIElementoDinamico.tittleLabel:
				goto IL_1209;
			case UIElementoDinamico.officePortrait:
				goto IL_0BE2;
			default:
				goto IL_12B5;
			}
			IEnumerable enumerable4 = (fieldInfo as FieldInfo).GetValue(modelOwner) as IEnumerable;
			int num2 = -1;
			using (IEnumerator enumerator = enumerable4.GetEnumerator())
			{
				while (enumerator.MoveNext())
				{
					object obj2 = enumerator.Current;
					num2++;
					IEnumerable<Attribute> enumerable5 = extradata.overrides.Concat(attr, modelOwner, fieldInfo.Name, num2);
					IUIElemento iuielemento2 = this.dibujarDeslizableConToolTip(panel, fieldInfo, modelOwner, num2, enumerable5, extradata);
					resultado.Add(iuielemento2);
				}
				return;
			}
			IL_03AE:
			IEnumerable enumerable6 = (fieldInfo as FieldInfo).GetValue(modelOwner) as IEnumerable;
			int num3 = -1;
			using (IEnumerator enumerator = enumerable6.GetEnumerator())
			{
				while (enumerator.MoveNext())
				{
					object obj3 = enumerator.Current;
					num3++;
					IEnumerable<Attribute> enumerable7 = extradata.overrides.Concat(attr, modelOwner, fieldInfo.Name, num3);
					IUIElemento iuielemento3 = this.dibujarDeslizableLabelCorto(panel, fieldInfo, modelOwner, num3, enumerable7, extradata);
					resultado.Add(iuielemento3);
				}
				return;
			}
			IL_045D:
			IEnumerable enumerable8 = (fieldInfo as FieldInfo).GetValue(modelOwner) as IEnumerable;
			int num4 = -1;
			using (IEnumerator enumerator = enumerable8.GetEnumerator())
			{
				while (enumerator.MoveNext())
				{
					object obj4 = enumerator.Current;
					num4++;
					IEnumerable<Attribute> enumerable9 = extradata.overrides.Concat(attr, modelOwner, fieldInfo.Name, num4);
					IUIElemento iuielemento4 = this.dibujarInputToolTip(panel, fieldInfo, modelOwner, num4, enumerable9, extradata);
					resultado.Add(iuielemento4);
				}
				return;
			}
			IL_050C:
			IEnumerable enumerable10 = (fieldInfo as FieldInfo).GetValue(modelOwner) as IEnumerable;
			int num5 = -1;
			using (IEnumerator enumerator = enumerable10.GetEnumerator())
			{
				while (enumerator.MoveNext())
				{
					object obj5 = enumerator.Current;
					num5++;
					IEnumerable<Attribute> enumerable11 = extradata.overrides.Concat(attr, modelOwner, fieldInfo.Name, num5);
					IUIElemento iuielemento5 = this.dibujarSelectablePortrait(panel, fieldInfo, modelOwner, num5, enumerable11, extradata);
					resultado.Add(iuielemento5);
				}
				return;
			}
			IL_05BB:
			IEnumerable enumerable12 = (fieldInfo as FieldInfo).GetValue(modelOwner) as IEnumerable;
			int num6 = -1;
			using (IEnumerator enumerator = enumerable12.GetEnumerator())
			{
				while (enumerator.MoveNext())
				{
					object obj6 = enumerator.Current;
					num6++;
					IEnumerable<Attribute> enumerable13 = extradata.overrides.Concat(attr, modelOwner, fieldInfo.Name, num6);
					IUIElemento iuielemento6 = this.dibujarSelectablePosePortrait(panel, fieldInfo, modelOwner, num6, enumerable13, extradata);
					resultado.Add(iuielemento6);
				}
				return;
			}
			IL_066A:
			IEnumerable enumerable14 = (fieldInfo as FieldInfo).GetValue(modelOwner) as IEnumerable;
			int num7 = -1;
			using (IEnumerator enumerator = enumerable14.GetEnumerator())
			{
				while (enumerator.MoveNext())
				{
					object obj7 = enumerator.Current;
					num7++;
					IEnumerable<Attribute> enumerable15 = extradata.overrides.Concat(attr, modelOwner, fieldInfo.Name, num7);
					IUIElemento iuielemento7 = this.dibujarSelectableGesturePortrait(panel, fieldInfo, modelOwner, num7, enumerable15, extradata);
					resultado.Add(iuielemento7);
				}
				return;
			}
			IL_0719:
			IEnumerable enumerable16 = (fieldInfo as FieldInfo).GetValue(modelOwner) as IEnumerable;
			int num8 = -1;
			using (IEnumerator enumerator = enumerable16.GetEnumerator())
			{
				while (enumerator.MoveNext())
				{
					object obj8 = enumerator.Current;
					num8++;
					IEnumerable<Attribute> enumerable17 = extradata.overrides.Concat(attr, modelOwner, fieldInfo.Name, num8);
					IUIElemento iuielemento8 = this.dibujarSelectableMakeoverPortrait(panel, fieldInfo, modelOwner, num8, enumerable17, extradata);
					resultado.Add(iuielemento8);
				}
				return;
			}
			IL_07C8:
			IEnumerable enumerable18 = (fieldInfo as FieldInfo).GetValue(modelOwner) as IEnumerable;
			int num9 = -1;
			using (IEnumerator enumerator = enumerable18.GetEnumerator())
			{
				while (enumerator.MoveNext())
				{
					object obj9 = enumerator.Current;
					num9++;
					IEnumerable<Attribute> enumerable19 = extradata.overrides.Concat(attr, modelOwner, fieldInfo.Name, num9);
					IUIElemento iuielemento9 = this.dibujarSelectableOutfitPortrait(panel, fieldInfo, modelOwner, num9, enumerable19, extradata);
					resultado.Add(iuielemento9);
				}
				return;
			}
			IL_0877:
			IEnumerable enumerable20 = (fieldInfo as FieldInfo).GetValue(modelOwner) as IEnumerable;
			int num10 = -1;
			using (IEnumerator enumerator = enumerable20.GetEnumerator())
			{
				while (enumerator.MoveNext())
				{
					object obj10 = enumerator.Current;
					num10++;
					IEnumerable<Attribute> enumerable21 = extradata.overrides.Concat(attr, modelOwner, fieldInfo.Name, num10);
					IUIElemento iuielemento10 = this.dibujarGameplayObjective(panel, fieldInfo, modelOwner, num10, enumerable21, extradata);
					resultado.Add(iuielemento10);
				}
				return;
			}
			IL_0926:
			IEnumerable enumerable22 = (fieldInfo as FieldInfo).GetValue(modelOwner) as IEnumerable;
			int num11 = -1;
			using (IEnumerator enumerator = enumerable22.GetEnumerator())
			{
				while (enumerator.MoveNext())
				{
					object obj11 = enumerator.Current;
					num11++;
					IEnumerable<Attribute> enumerable23 = extradata.overrides.Concat(attr, modelOwner, fieldInfo.Name, num11);
					IUIElemento iuielemento11 = this.dibujarSelectableWorkingModelPortrait(panel, fieldInfo, modelOwner, num11, enumerable23, extradata);
					resultado.Add(iuielemento11);
				}
				return;
			}
			IL_09D5:
			IEnumerable enumerable24 = (fieldInfo as FieldInfo).GetValue(modelOwner) as IEnumerable;
			int num12 = -1;
			using (IEnumerator enumerator = enumerable24.GetEnumerator())
			{
				while (enumerator.MoveNext())
				{
					object obj12 = enumerator.Current;
					num12++;
					IEnumerable<Attribute> enumerable25 = extradata.overrides.Concat(attr, modelOwner, fieldInfo.Name, num12);
					IUIElemento iuielemento12 = this.dibujarSelectableFavoritableGenericPortrait(panel, fieldInfo, modelOwner, num12, enumerable25, extradata);
					resultado.Add(iuielemento12);
				}
				return;
			}
			IL_0A84:
			IEnumerable enumerable26 = (fieldInfo as FieldInfo).GetValue(modelOwner) as IEnumerable;
			int num13 = -1;
			using (IEnumerator enumerator = enumerable26.GetEnumerator())
			{
				while (enumerator.MoveNext())
				{
					object obj13 = enumerator.Current;
					num13++;
					IEnumerable<Attribute> enumerable27 = extradata.overrides.Concat(attr, modelOwner, fieldInfo.Name, num13);
					IUIElemento iuielemento13 = this.dibujarSelectableProfilePortrait(panel, fieldInfo, modelOwner, num13, enumerable27, extradata);
					resultado.Add(iuielemento13);
				}
				return;
			}
			IL_0B33:
			IEnumerable enumerable28 = (fieldInfo as FieldInfo).GetValue(modelOwner) as IEnumerable;
			int num14 = -1;
			using (IEnumerator enumerator = enumerable28.GetEnumerator())
			{
				while (enumerator.MoveNext())
				{
					object obj14 = enumerator.Current;
					num14++;
					IEnumerable<Attribute> enumerable29 = extradata.overrides.Concat(attr, modelOwner, fieldInfo.Name, num14);
					IUIElemento iuielemento14 = this.dibujarSelectableJobPortrait(panel, fieldInfo, modelOwner, num14, enumerable29, extradata);
					resultado.Add(iuielemento14);
				}
				return;
			}
			IL_0BE2:
			IEnumerable enumerable30 = (fieldInfo as FieldInfo).GetValue(modelOwner) as IEnumerable;
			int num15 = -1;
			using (IEnumerator enumerator = enumerable30.GetEnumerator())
			{
				while (enumerator.MoveNext())
				{
					object obj15 = enumerator.Current;
					num15++;
					IEnumerable<Attribute> enumerable31 = extradata.overrides.Concat(attr, modelOwner, fieldInfo.Name, num15);
					IUIElemento iuielemento15 = this.dibujarSelectableOfficePortrait(panel, fieldInfo, modelOwner, num15, enumerable31, extradata);
					resultado.Add(iuielemento15);
				}
				return;
			}
			IL_0C91:
			IEnumerable enumerable32 = (fieldInfo as FieldInfo).GetValue(modelOwner) as IEnumerable;
			int num16 = -1;
			using (IEnumerator enumerator = enumerable32.GetEnumerator())
			{
				while (enumerator.MoveNext())
				{
					object obj16 = enumerator.Current;
					num16++;
					IEnumerable<Attribute> enumerable33 = extradata.overrides.Concat(attr, modelOwner, fieldInfo.Name, num16);
					IUIElemento iuielemento16 = this.dibujarClickableLabel(panel, fieldInfo, modelOwner, num16, enumerable33, extradata);
					resultado.Add(iuielemento16);
				}
				return;
			}
			IL_0D40:
			IEnumerable enumerable34 = (fieldInfo as FieldInfo).GetValue(modelOwner) as IEnumerable;
			int num17 = -1;
			using (IEnumerator enumerator = enumerable34.GetEnumerator())
			{
				while (enumerator.MoveNext())
				{
					object obj17 = enumerator.Current;
					num17++;
					IEnumerable<Attribute> enumerable35 = extradata.overrides.Concat(attr, modelOwner, fieldInfo.Name, num17);
					IUIElemento iuielemento17 = this.dibujarClickableLabelConValor(panel, fieldInfo, modelOwner, num17, enumerable35, extradata);
					resultado.Add(iuielemento17);
				}
				return;
			}
			IL_0DEF:
			IEnumerable enumerable36 = (fieldInfo as FieldInfo).GetValue(modelOwner) as IEnumerable;
			int num18 = -1;
			using (IEnumerator enumerator = enumerable36.GetEnumerator())
			{
				while (enumerator.MoveNext())
				{
					object obj18 = enumerator.Current;
					num18++;
					IEnumerable<Attribute> enumerable37 = extradata.overrides.Concat(attr, modelOwner, fieldInfo.Name, num18);
					IUIElemento iuielemento18 = this.dibujarClickableLabelFav(panel, fieldInfo, modelOwner, num18, enumerable37, extradata);
					resultado.Add(iuielemento18);
				}
				return;
			}
			IL_0E9E:
			IEnumerable enumerable38 = (fieldInfo as FieldInfo).GetValue(modelOwner) as IEnumerable;
			int num19 = -1;
			using (IEnumerator enumerator = enumerable38.GetEnumerator())
			{
				while (enumerator.MoveNext())
				{
					object obj19 = enumerator.Current;
					num19++;
					IEnumerable<Attribute> enumerable39 = extradata.overrides.Concat(attr, modelOwner, fieldInfo.Name, num19);
					IUIElemento iuielemento19 = this.dibujaLabelPar(panel, fieldInfo, modelOwner, num19, enumerable39, extradata);
					resultado.Add(iuielemento19);
				}
				return;
			}
			IL_0F4D:
			IEnumerable enumerable40 = (fieldInfo as FieldInfo).GetValue(modelOwner) as IEnumerable;
			int num20 = -1;
			using (IEnumerator enumerator = enumerable40.GetEnumerator())
			{
				while (enumerator.MoveNext())
				{
					object obj20 = enumerator.Current;
					num20++;
					IEnumerable<Attribute> enumerable41 = extradata.overrides.Concat(attr, modelOwner, fieldInfo.Name, num20);
					IUIElemento iuielemento20 = this.dibujaLabelCortoLabelLargoPar(panel, fieldInfo, modelOwner, num20, enumerable41, extradata);
					resultado.Add(iuielemento20);
				}
				return;
			}
			IL_0FFC:
			IEnumerable enumerable42 = (fieldInfo as FieldInfo).GetValue(modelOwner) as IEnumerable;
			int num21 = -1;
			using (IEnumerator enumerator = enumerable42.GetEnumerator())
			{
				while (enumerator.MoveNext())
				{
					object obj21 = enumerator.Current;
					num21++;
					IEnumerable<Attribute> enumerable43 = extradata.overrides.Concat(attr, modelOwner, fieldInfo.Name, num21);
					IUIElemento iuielemento21 = this.dibujaLabelCortoLevel(panel, fieldInfo, modelOwner, num21, enumerable43, extradata);
					resultado.Add(iuielemento21);
				}
				return;
			}
			IL_10AB:
			IEnumerable enumerable44 = (fieldInfo as FieldInfo).GetValue(modelOwner) as IEnumerable;
			int num22 = -1;
			using (IEnumerator enumerator = enumerable44.GetEnumerator())
			{
				while (enumerator.MoveNext())
				{
					object obj22 = enumerator.Current;
					num22++;
					IEnumerable<Attribute> enumerable45 = extradata.overrides.Concat(attr, modelOwner, fieldInfo.Name, num22);
					IUIElemento iuielemento22 = this.dibujarClickableDescriptableLabel(panel, fieldInfo, modelOwner, num22, enumerable45, extradata);
					resultado.Add(iuielemento22);
				}
				return;
			}
			IL_115A:
			IEnumerable enumerable46 = (fieldInfo as FieldInfo).GetValue(modelOwner) as IEnumerable;
			int num23 = -1;
			using (IEnumerator enumerator = enumerable46.GetEnumerator())
			{
				while (enumerator.MoveNext())
				{
					object obj23 = enumerator.Current;
					num23++;
					IEnumerable<Attribute> enumerable47 = extradata.overrides.Concat(attr, modelOwner, fieldInfo.Name, num23);
					IUIElemento iuielemento23 = this.dibujarClickableDescriptableLabelCompacto(panel, fieldInfo, modelOwner, num23, enumerable47, extradata);
					resultado.Add(iuielemento23);
				}
				return;
			}
			IL_1209:
			IEnumerable enumerable48 = (fieldInfo as FieldInfo).GetValue(modelOwner) as IEnumerable;
			int num24 = -1;
			using (IEnumerator enumerator = enumerable48.GetEnumerator())
			{
				while (enumerator.MoveNext())
				{
					object obj24 = enumerator.Current;
					num24++;
					IEnumerable<Attribute> enumerable49 = extradata.overrides.Concat(attr, modelOwner, fieldInfo.Name, num24);
					IUIElemento iuielemento24 = this.dibujaTitleLabel(panel, fieldInfo, modelOwner, num24, enumerable49, extradata);
					resultado.Add(iuielemento24);
				}
				return;
			}
			IL_12B5:
			throw new ArgumentOutOfRangeException(customAttribute2.tipo.ToString());
		}

		// Token: 0x06000398 RID: 920 RVA: 0x0000A644 File Offset: 0x00008844
		public void BindPanel(IUIPanel panel, object instance)
		{
			if (panel.isBinded)
			{
				throw new InvalidOperationException();
			}
			panel.Bind("Root", instance.GetType(), false);
		}

		// Token: 0x06000399 RID: 921 RVA: 0x0000A668 File Offset: 0x00008868
		public void BindSubPanel(IUIPanel panel, IUIPanel parentPanel, string subPanelFieldName)
		{
			if (!parentPanel.isBinded)
			{
				throw new InvalidOperationException();
			}
			MemberInfo memberInfo = parentPanel.modelType.GetMember(subPanelFieldName, BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.FlattenHierarchy).FirstOrDefault<MemberInfo>();
			Attribute[] customAttributes = Attribute.GetCustomAttributes(parentPanel.modelType, true);
			this.BindSubPanel(panel, memberInfo, memberInfo.Name, false, customAttributes);
		}

		// Token: 0x0600039A RID: 922 RVA: 0x0000A6B4 File Offset: 0x000088B4
		private void BindSubPanel(IUIPanel panel, MemberInfo info, string modelName, bool isListItem, IEnumerable<Attribute> attr)
		{
			if (panel.isBinded)
			{
				throw new InvalidOperationException();
			}
			panel.Bind(modelName, info.GetUnderlyingType(), isListItem);
			this.SecAddModel(panel, info, attr);
		}

		// Token: 0x0600039B RID: 923 RVA: 0x0000A6E0 File Offset: 0x000088E0
		public IUIPanel DibujarPanel(object model, Transform target, ref DibujadorDynamico.ExtraData extraData, FieldInfo ownInfoAsField = null, IEnumerable<Attribute> aditinalPanelAttributes = null, int? index = null)
		{
			IUIPanel iuipanel = this.dibujarPanel(model, ownInfoAsField, (index == null) ? (-1) : index.Value, null, null, ref extraData, null, aditinalPanelAttributes);
			if (iuipanel != null)
			{
				iuipanel.transform.SetParent(target, false);
				if (index != null)
				{
					iuipanel.transform.SetSiblingIndex(index.Value);
				}
			}
			return iuipanel;
		}

		// Token: 0x0600039C RID: 924 RVA: 0x0000A73C File Offset: 0x0000893C
		public DibujadorDynamico.ModelEstructura GetModelEstructura(object model)
		{
			DibujadorDynamico.ExtraData extraData = null;
			return this.getModelEstructura(model, null, null, ref extraData, -1);
		}

		// Token: 0x0600039D RID: 925 RVA: 0x0000A758 File Offset: 0x00008958
		private DibujadorDynamico.ModelEstructura getModelEstructura(object model, FieldInfo fieldInfoInParentModel, object modelParent, ref DibujadorDynamico.ExtraData extraData, int indexInParentModel = -1)
		{
			if (model == null)
			{
				return null;
			}
			Type type = model.GetType();
			IEnumerable<Attribute> enumerable;
			if (fieldInfoInParentModel != null)
			{
				enumerable = fieldInfoInParentModel.GetCustomAttributes().Concat(type.GetCustomAttributes());
			}
			else
			{
				enumerable = type.GetCustomAttributes();
			}
			if (enumerable.FirstOrDefault((Attribute a) => a is ModeloAttribute) == null)
			{
				return null;
			}
			MemberInfo[] modelMembers = this.GetModelMembers(type);
			this.LoadExtraData(modelMembers, model, ref extraData);
			DibujadorDynamico.ModelEstructura modelEstructura = new DibujadorDynamico.ModelEstructura();
			modelEstructura.modelParent = modelParent;
			modelEstructura.modelCurrent = model;
			modelEstructura.currentInfoInModel = fieldInfoInParentModel;
			modelEstructura.index = indexInParentModel;
			modelEstructura.attributes = enumerable;
			foreach (MemberInfo memberInfo in modelMembers)
			{
				Func<bool> func;
				if (!Attribute.IsDefined(memberInfo, typeof(Assets.Base.Plugins.Runtime.UI.IgnoreAttribute), true) && !Attribute.IsDefined(memberInfo, typeof(Assets.TValle.Tools.Runtime.UI.IgnoreAttribute), true) && (!extraData.paraType.ignoreIf.TryGetValue(new ValueTuple<Type, string>(type, memberInfo.Name), out func) || !((func != null) ? new bool?(func()) : null).GetValueOrDefault()) && (memberInfo.IsDefined(typeof(OrderAttribute), true) || memberInfo.IsDefined(typeof(TValleUIAttribute), true)))
				{
					FieldInfo fieldInfo = memberInfo as FieldInfo;
					IEnumerable<Attribute> customAttributes = memberInfo.GetCustomAttributes();
					if (DibujadorDynamico.IsList(memberInfo))
					{
						if (memberInfo.IsDefined(typeof(ModeloAttribute), true) || (fieldInfo != null && fieldInfo.FieldType.IsDefined(typeof(ModeloAttribute), true) && fieldInfo != null))
						{
							IEnumerable enumerable2 = fieldInfo.GetValue(model) as IEnumerable;
							int num = 0;
							using (IEnumerator enumerator = enumerable2.GetEnumerator())
							{
								while (enumerator.MoveNext())
								{
									object obj = enumerator.Current;
									DibujadorDynamico.ModelEstructura modelEstructura2 = this.getModelEstructura(obj, fieldInfo, model, ref extraData, num);
									modelEstructura.children.Add(modelEstructura2);
									num++;
								}
								goto IL_034B;
							}
						}
						IEnumerable enumerable3 = ((fieldInfo != null) ? fieldInfo.GetValue(model) : null) as IEnumerable;
						int num2 = -1;
						using (IEnumerator enumerator = enumerable3.GetEnumerator())
						{
							while (enumerator.MoveNext())
							{
								object obj2 = enumerator.Current;
								num2++;
								DibujadorDynamico.ModelEstructura modelEstructura3 = new DibujadorDynamico.ModelEstructura
								{
									currentInfoInModel = memberInfo,
									index = num2,
									modelCurrent = null,
									modelParent = model,
									attributes = customAttributes
								};
								modelEstructura.children.Add(modelEstructura3);
							}
							goto IL_034B;
						}
					}
					if (memberInfo.IsDefined(typeof(ModeloAttribute), true) || (fieldInfo != null && fieldInfo.FieldType.IsDefined(typeof(ModeloAttribute), true) && fieldInfo != null))
					{
						object value = fieldInfo.GetValue(model);
						DibujadorDynamico.ModelEstructura modelEstructura4 = this.getModelEstructura(value, fieldInfo, model, ref extraData, -1);
						modelEstructura.children.Add(modelEstructura4);
					}
					else
					{
						DibujadorDynamico.ModelEstructura modelEstructura5 = new DibujadorDynamico.ModelEstructura
						{
							currentInfoInModel = memberInfo,
							index = -1,
							modelCurrent = null,
							modelParent = model,
							attributes = customAttributes
						};
						modelEstructura.children.Add(modelEstructura5);
					}
				}
				IL_034B:;
			}
			return modelEstructura;
		}

		// Token: 0x0600039E RID: 926 RVA: 0x0000AAE0 File Offset: 0x00008CE0
		private MemberInfo[] GetModelMembers(Type tipo)
		{
			IEnumerable<MemberInfo> enumerable = from m in tipo.GetMembers(BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.FlattenHierarchy)
				where m is FieldInfo || m is MethodInfo || m is PropertyInfo
				select m;
			IOrderedEnumerable<MemberInfo> miembrosConOrden = from m in enumerable
				where Attribute.IsDefined(m, typeof(OrderAttribute), true)
				orderby m.GetCustomAttributes(true).Aggregate(delegate(OrderAttribute a, OrderAttribute b)
				{
					if (a.Order <= b.Order)
					{
						return b;
					}
					return a;
				}).Order
				select m;
			IOrderedEnumerable<MemberInfo> miembrosConOrdenModding = from m in enumerable
				where Attribute.IsDefined(m, typeof(TValleUIAttribute), true)
				orderby m.GetCustomAttributes(true).Aggregate(delegate(TValleUIAttribute a, TValleUIAttribute b)
				{
					if (a.Order <= b.Order)
					{
						return b;
					}
					return a;
				}).Order
				select m;
			IEnumerable<MemberInfo> enumerable2 = enumerable.Where((MemberInfo m) => !miembrosConOrden.Contains(m) && !miembrosConOrdenModding.Contains(m));
			return miembrosConOrden.Concat(miembrosConOrdenModding).Concat(enumerable2).ToArray<MemberInfo>();
		}

		// Token: 0x0600039F RID: 927 RVA: 0x0000ABF0 File Offset: 0x00008DF0
		private IUIPanel dibujarPanel(object model, FieldInfo fieldInfoInParentModel, int index, IUIPanel parentPanel, object modelParent, ref DibujadorDynamico.ExtraData extraData, List<IUIElemento> todosLosElementosResultado = null, IEnumerable<Attribute> aditinalPanelAttributes = null)
		{
			if (model == null)
			{
				return null;
			}
			Type type = model.GetType();
			IEnumerable<Attribute> enumerable;
			if (fieldInfoInParentModel != null)
			{
				enumerable = fieldInfoInParentModel.GetCustomAttributes().Concat(type.GetCustomAttributes());
			}
			else
			{
				enumerable = type.GetCustomAttributes();
			}
			if (aditinalPanelAttributes != null)
			{
				enumerable = enumerable.Concat(aditinalPanelAttributes);
			}
			DibujadorDynamico.ExtraData extraData2 = extraData;
			if (((extraData2 != null) ? extraData2.overrides : null) != null)
			{
				enumerable = extraData.overrides.Concat(enumerable, model, (fieldInfoInParentModel != null) ? fieldInfoInParentModel.Name : null, index);
			}
			if (enumerable.FirstOrDefault((Attribute a) => a is ModeloAttribute) == null)
			{
				if (enumerable.FirstOrDefault((Attribute a) => a is ModelAttribute) == null)
				{
					return null;
				}
			}
			MemberInfo[] modelMembers = this.GetModelMembers(type);
			this.LoadExtraData(modelMembers, model, ref extraData);
			IUIPanel panel = this.InstanciarPanel(model, fieldInfoInParentModel, index, enumerable, extraData, parentPanel);
			IUIPanelConBotones iuipanelConBotones = panel as IUIPanelConBotones;
			if (iuipanelConBotones != null)
			{
				Transform padreParaBotones = iuipanelConBotones.padreParaBotones;
				if (padreParaBotones != null)
				{
					padreParaBotones.gameObject.SetActive(false);
				}
			}
			this.setAtributosAPanel(panel, enumerable);
			if (!this.addDynamicTitle(model, panel, type, fieldInfoInParentModel, modelParent, enumerable, modelMembers, extraData) && !this.addTitle(panel, type, fieldInfoInParentModel, modelParent, enumerable, extraData) && !this.addTitleOld(panel, type, fieldInfoInParentModel, modelParent, enumerable, extraData))
			{
				IUIPanelConTitulo iuipanelConTitulo = panel as IUIPanelConTitulo;
				Transform transform = ((iuipanelConTitulo != null) ? iuipanelConTitulo.padreParaTitulos : null);
				if (transform != null && panel.GetParentPara(0) != transform && transform != null)
				{
					transform.gameObject.SetActive(false);
				}
			}
			if (todosLosElementosResultado == null)
			{
				todosLosElementosResultado = new List<IUIElemento>();
			}
			Dictionary<string, IUIElemento> dictionary = new Dictionary<string, IUIElemento>();
			List<IUIElemento> list = new List<IUIElemento>();
			Dictionary<string, IUIElemento> dictionary2 = new Dictionary<string, IUIElemento>();
			foreach (MemberInfo memberInfo in modelMembers)
			{
				Func<bool> func;
				if (!Attribute.IsDefined(memberInfo, typeof(Assets.Base.Plugins.Runtime.UI.IgnoreAttribute), true) && !Attribute.IsDefined(memberInfo, typeof(Assets.TValle.Tools.Runtime.UI.IgnoreAttribute), true) && (!extraData.paraType.ignoreIf.TryGetValue(new ValueTuple<Type, string>(type, memberInfo.Name), out func) || !((func != null) ? new bool?(func()) : null).GetValueOrDefault()) && (memberInfo.IsDefined(typeof(OrderAttribute), true) || memberInfo.IsDefined(typeof(TValleUIAttribute), true)))
				{
					FieldInfo fieldInfo = memberInfo as FieldInfo;
					IEnumerable<Attribute> customAttributes = memberInfo.GetCustomAttributes();
					if (DibujadorDynamico.IsList(memberInfo))
					{
						if (memberInfo.IsDefined(typeof(ModeloAttribute), true) || (fieldInfo != null && fieldInfo.FieldType.IsDefined(typeof(ModeloAttribute), true) && fieldInfo != null))
						{
							IEnumerable enumerable2 = fieldInfo.GetValue(model) as IEnumerable;
							int num = 0;
							using (IEnumerator enumerator = enumerable2.GetEnumerator())
							{
								while (enumerator.MoveNext())
								{
									object obj = enumerator.Current;
									IUIPanel iuipanel = this.dibujarPanel(obj, fieldInfo, num, panel, model, ref extraData, todosLosElementosResultado, null);
									if (iuipanel != null)
									{
										string text = JsonUtility.ToJson(new ModeloConIndex
										{
											index = num,
											modeloName = memberInfo.Name
										});
										list.Add(iuipanel);
										dictionary2.Add(text, iuipanel);
										this.BindSubPanel(iuipanel, memberInfo, text, true, customAttributes);
									}
									num++;
								}
								goto IL_04CE;
							}
						}
						List<IUIElemento> list2 = new List<IUIElemento>();
						this.dibujarUIElementos(panel, list2, memberInfo, model, customAttributes, extraData);
						for (int j = 0; j < list2.Count; j++)
						{
							if (list2[j] != null)
							{
								dictionary.Add(JsonUtility.ToJson(new ModeloConIndex
								{
									index = j,
									modeloName = memberInfo.Name
								}), list2[j]);
							}
						}
					}
					else if (memberInfo.IsDefined(typeof(ModeloAttribute), true) || (fieldInfo != null && fieldInfo.FieldType.IsDefined(typeof(ModeloAttribute), true) && fieldInfo != null))
					{
						object value = fieldInfo.GetValue(model);
						IUIPanel iuipanel2 = this.dibujarPanel(value, fieldInfo, -1, panel, model, ref extraData, todosLosElementosResultado, null);
						if (iuipanel2 != null)
						{
							list.Add(iuipanel2);
							dictionary2.Add(memberInfo.Name, iuipanel2);
							this.BindSubPanel(iuipanel2, memberInfo, memberInfo.Name, false, customAttributes);
						}
					}
					else
					{
						IUIElemento iuielemento = this.dibujarUIElemento(panel, memberInfo, model, customAttributes, extraData);
						if (iuielemento != null)
						{
							dictionary.Add(memberInfo.Name, iuielemento);
						}
					}
				}
				IL_04CE:;
			}
			Dictionary<IUIElemento, List<IUIElemento>> dictionary3 = new Dictionary<IUIElemento, List<IUIElemento>>();
			foreach (MemberInfo memberInfo2 in modelMembers)
			{
				IUIElemento iuielemento2;
				if (dictionary.TryGetValue(memberInfo2.Name, out iuielemento2))
				{
					LinkedAttribute linkedAttribute = memberInfo2.GetCustomAttributes(typeof(LinkedAttribute), true).FirstOrDefault<object>() as LinkedAttribute;
					if (linkedAttribute != null)
					{
						string to = linkedAttribute.to;
						IUIElemento iuielemento3;
						if (dictionary.TryGetValue(to, out iuielemento3))
						{
							List<IUIElemento> list3;
							if (!dictionary3.TryGetValue(iuielemento3, out list3))
							{
								list3 = new List<IUIElemento>();
								dictionary3.Add(iuielemento3, list3);
							}
							list3.Add(iuielemento2);
						}
					}
				}
			}
			foreach (MemberInfo memberInfo3 in modelMembers)
			{
				Func<bool> func2;
				if (!Attribute.IsDefined(memberInfo3, typeof(Assets.Base.Plugins.Runtime.UI.IgnoreAttribute), true) && !Attribute.IsDefined(memberInfo3, typeof(Assets.TValle.Tools.Runtime.UI.IgnoreAttribute), true) && (!extraData.paraType.ignoreIf.TryGetValue(new ValueTuple<Type, string>(type, memberInfo3.Name), out func2) || !((func2 != null) ? new bool?(func2()) : null).GetValueOrDefault()))
				{
					bool flag = memberInfo3.IsDefined(typeof(IgnoreValueAttribute));
					IEnumerable<Attribute> customAttributes2 = memberInfo3.GetCustomAttributes();
					if (DibujadorDynamico.IsList(memberInfo3))
					{
						FieldInfo fieldInfo2 = memberInfo3 as FieldInfo;
						object obj2;
						if (fieldInfo2 != null)
						{
							obj2 = fieldInfo2.GetValue(model);
						}
						else
						{
							obj2 = null;
						}
						if (obj2 != null)
						{
							IList list4 = (IList)obj2;
							for (int k = 0; k < list4.Count; k++)
							{
								string text2 = JsonUtility.ToJson(new ModeloConIndex
								{
									index = k,
									modeloName = memberInfo3.Name
								});
								IUIElemento iuielemento4;
								if (dictionary.TryGetValue(text2, out iuielemento4))
								{
									object obj3 = (flag ? null : list4[k]);
									this.SetLinkedElements(dictionary3, iuielemento4);
									this.BindElemento(panel, iuielemento4, memberInfo3, text2, obj3, model, flag, true, customAttributes2);
									list.Add(iuielemento4);
									dictionary2.Add(text2, iuielemento4);
								}
							}
						}
					}
					else
					{
						object obj4;
						if (flag)
						{
							obj4 = null;
						}
						else
						{
							FieldInfo fieldInfo3 = memberInfo3 as FieldInfo;
							PropertyInfo propertyInfo = memberInfo3 as PropertyInfo;
							if (fieldInfo3 != null)
							{
								obj4 = fieldInfo3.GetValue(model);
							}
							else if (propertyInfo != null)
							{
								obj4 = propertyInfo.GetValue(model);
							}
							else
							{
								obj4 = null;
							}
						}
						IUIElemento iuielemento5;
						if (dictionary.TryGetValue(memberInfo3.Name, out iuielemento5))
						{
							this.SetLinkedElements(dictionary3, iuielemento5);
							this.BindElemento(panel, iuielemento5, memberInfo3, memberInfo3.Name, obj4, model, flag, false, customAttributes2);
							list.Add(iuielemento5);
							dictionary2.Add(memberInfo3.Name, iuielemento5);
						}
					}
				}
			}
			panel.AddElementos(dictionary2);
			dictionary2.ForEach(delegate(KeyValuePair<string, IUIElemento> par)
			{
				par.Value.AddedTo(panel.transform);
			});
			DibujadorDynamico.addListinersToPanel(panel, model, modelMembers, list, todosLosElementosResultado);
			DibujadorDynamico.addExtraDataToPanel(panel, model, extraData);
			todosLosElementosResultado.AddRange(list);
			extraData.todosLosDibujados.UnionWith(todosLosElementosResultado);
			return panel;
		}

		// Token: 0x060003A0 RID: 928 RVA: 0x0000B410 File Offset: 0x00009610
		private static void addExtraDataToPanel(IUIPanel panel, object model, DibujadorDynamico.ExtraData extraData)
		{
			if (extraData == null || extraData.paraModel.dataDelegates == null)
			{
				return;
			}
			IUIPanelConExtraData iuipanelConExtraData = panel as IUIPanelConExtraData;
			if (iuipanelConExtraData == null)
			{
				return;
			}
			Dictionary<string, Func<object>> dictionary = new Dictionary<string, Func<object>>();
			foreach (KeyValuePair<ValueTuple<object, string>, List<Func<object>>> keyValuePair in extraData.paraModel.dataDelegates)
			{
				if (model == keyValuePair.Key.Item1)
				{
					if (keyValuePair.Value.Count > 1)
					{
						Debug.LogError("Data Para Modelo Panel NO es conpatible con varios data extra en el mismo modelID");
					}
					Func<object> func = keyValuePair.Value.FirstOrDefault<Func<object>>();
					dictionary.Add(keyValuePair.Key.Item2, func);
				}
			}
			iuipanelConExtraData.SetExtraData(dictionary);
		}

		// Token: 0x060003A1 RID: 929 RVA: 0x0000B4D4 File Offset: 0x000096D4
		private static void addListinersToPanel(IUIPanel panel, object model, IList<MemberInfo> miembros, IEnumerable<IUIElemento> toListen, IEnumerable<IUIElemento> todosLosElementosAnteriores = null)
		{
			IUIPanelConEventos iuipanelConEventos = panel as IUIPanelConEventos;
			Func<IUIElemento, bool> <>9__0;
			foreach (MemberInfo memberInfo in miembros)
			{
				MethodInfo methodInfo = memberInfo as MethodInfo;
				if (methodInfo != null)
				{
					ModelValueChangedListenerAttribute customAttribute = memberInfo.GetCustomAttribute(true);
					if (customAttribute != null)
					{
						IEnumerable<IUIElemento> enumerable;
						if (todosLosElementosAnteriores != null && customAttribute.escucharTodosLosElementosAnteriores)
						{
							enumerable = todosLosElementosAnteriores;
						}
						else if (todosLosElementosAnteriores != null && customAttribute.escucharSubElementosDeEsteModel)
						{
							Func<IUIElemento, bool> func;
							if ((func = <>9__0) == null)
							{
								func = (<>9__0 = (IUIElemento ele) => panel.EsPadreDe(ele));
							}
							enumerable = todosLosElementosAnteriores.Where(func).ToArray<IUIElemento>();
						}
						else
						{
							enumerable = null;
						}
						DibujadorDynamico.SetDelegadoAModelChanged(toListen, methodInfo, panel, model, enumerable);
					}
					else
					{
						object[] array = memberInfo.GetCustomAttributes(typeof(MemberValueChangedListenerAttribute), true);
						for (int i = 0; i < array.Length; i++)
						{
							MemberValueChangedListenerAttribute memberListiner2 = (MemberValueChangedListenerAttribute)array[i];
							IEnumerable<IUIElemento> enumerable2 = from mem in toListen
								where mem.modelName == memberListiner2.member
								select mem into e
								where e is IUIElementoConValor
								select e;
							if (enumerable2 == null || enumerable2.Count<IUIElemento>() == 0)
							{
								if (Application.isEditor)
								{
									Debug.LogWarning("No se pudo definir listener para miembro: " + memberListiner2.member, panel as Object);
								}
							}
							else
							{
								foreach (IUIElemento iuielemento in enumerable2)
								{
									DibujadorDynamico.SetDelegadoAElementoConValor(iuielemento, methodInfo, panel, model);
								}
							}
						}
						array = memberInfo.GetCustomAttributes(typeof(MemberBotonClickedListenerAttribute), true);
						for (int i = 0; i < array.Length; i++)
						{
							MemberBotonClickedListenerAttribute memberListiner3 = (MemberBotonClickedListenerAttribute)array[i];
							IEnumerable<IUIElemento> enumerable3 = from mem in toListen
								where mem.modelName == memberListiner3.member
								select mem into e
								where e is IUIBoton
								select e;
							if (enumerable3 != null && enumerable3.Count<IUIElemento>() != 0)
							{
								foreach (IUIElemento iuielemento2 in enumerable3)
								{
									DibujadorDynamico.SetDelegadoAConfirmableConElemento(iuielemento2, methodInfo, panel, model);
								}
							}
						}
						array = memberInfo.GetCustomAttributes(typeof(MemberClickedListenerAttribute), true);
						for (int i = 0; i < array.Length; i++)
						{
							MemberClickedListenerAttribute memberListiner = (MemberClickedListenerAttribute)array[i];
							IEnumerable<IUIElemento> enumerable4 = from mem in toListen
								where mem.modelName == memberListiner.member
								select mem into e
								where e is IUIElementoClickable
								select e;
							if (enumerable4 != null && enumerable4.Count<IUIElemento>() != 0)
							{
								foreach (IUIElemento iuielemento3 in enumerable4)
								{
									DibujadorDynamico.SetDelegadoAClickableConElemento(iuielemento3, methodInfo, panel, model);
								}
							}
						}
						if (iuipanelConEventos != null && memberInfo.GetCustomAttribute(typeof(PanelEventListenerAttribute), true) != null)
						{
							DibujadorDynamico.SetDelegadoAPanel(methodInfo, iuipanelConEventos, model);
						}
					}
				}
			}
		}

		// Token: 0x060003A2 RID: 930 RVA: 0x0000B8A8 File Offset: 0x00009AA8
		public void AddListinersToPanel(IUIPanel panel, object model, IEnumerable<IUIElemento> toListen, IEnumerable<IUIElemento> toListenExtra = null)
		{
			if (model == null)
			{
				return;
			}
			if (panel == null)
			{
				return;
			}
			if (!panel.isBinded)
			{
				return;
			}
			MethodInfo[] methods = model.GetType().GetMethods(BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.FlattenHierarchy);
			DibujadorDynamico.addListinersToPanel(panel, model, methods, toListen, toListenExtra);
		}

		// Token: 0x060003A3 RID: 931 RVA: 0x0000B8DF File Offset: 0x00009ADF
		public static bool IsList(MemberInfo memberInfo)
		{
			if (memberInfo is FieldInfo)
			{
				return DibujadorDynamico.IsList((FieldInfo)memberInfo);
			}
			return memberInfo is PropertyInfo && DibujadorDynamico.IsList((PropertyInfo)memberInfo);
		}

		// Token: 0x060003A4 RID: 932 RVA: 0x0000B90A File Offset: 0x00009B0A
		public static bool IsList(FieldInfo fieldInfo)
		{
			return DibujadorDynamico.IsList(fieldInfo.FieldType);
		}

		// Token: 0x060003A5 RID: 933 RVA: 0x0000B917 File Offset: 0x00009B17
		public static bool IsList(PropertyInfo propertyInfo)
		{
			return DibujadorDynamico.IsList(propertyInfo.PropertyType);
		}

		// Token: 0x060003A6 RID: 934 RVA: 0x0000B924 File Offset: 0x00009B24
		public static bool IsList(Type type)
		{
			return type.IsArray || (type.IsGenericType && type.GetGenericTypeDefinition() == typeof(List<>));
		}

		// Token: 0x060003A7 RID: 935 RVA: 0x0000B950 File Offset: 0x00009B50
		private void LoadExtraData(IReadOnlyList<MemberInfo> miembros, object model, ref DibujadorDynamico.ExtraData extraData)
		{
			if (extraData == null)
			{
				extraData = new DibujadorDynamico.ExtraData();
			}
			List<MemberInfo> list = extraData.paraType.miembrosV2;
			Dictionary<ValueTuple<Type, string>, MemberInfo> dic = extraData.paraType.miembrosDiccV2;
			miembros.ForEach(delegate(MemberInfo m)
			{
				try
				{
					if (dic.TryAdd(new ValueTuple<Type, string>(model.GetType(), m.Name), m))
					{
						list.Add(m);
					}
				}
				catch (Exception)
				{
					throw;
				}
			});
			if (extraData.paraType.typesAdded.Add(model.GetType()))
			{
				Type type = model.GetType();
				foreach (MemberInfo memberInfo in miembros)
				{
					IEnumerable<Attribute> enumerable = memberInfo.GetCustomAttributes();
					enumerable = extraData.overrides.Concat(enumerable, model, memberInfo.Name, -1);
					MethodInfo methodInfo = memberInfo as MethodInfo;
					if (methodInfo != null)
					{
						ParameterInfo[] parameters = methodInfo.GetParameters();
						Type returnType = methodInfo.ReturnType;
						if (parameters.Length == 1)
						{
							if (returnType == typeof(IList<IUIElemento>))
							{
								Func<IUIPanel, IList<IUIElemento>> func;
								try
								{
									func = (Func<IUIPanel, IList<IUIElemento>>)methodInfo.CreateDelegate(typeof(Func<IUIPanel, IList<IUIElemento>>), model);
								}
								catch (Exception ex)
								{
									Debug.LogException(new NotSupportedException(ex.Message, ex));
									func = null;
								}
								extraData.paraType.selfDrawingListMetodo.AddOrReplase(new ValueTuple<Type, string>(type, memberInfo.Name), func);
							}
							if (returnType == typeof(IUIElemento))
							{
								Func<IUIPanel, IUIElemento> func2;
								try
								{
									func2 = (Func<IUIPanel, IUIElemento>)methodInfo.CreateDelegate(typeof(Func<IUIPanel, IUIElemento>), model);
								}
								catch (Exception ex2)
								{
									Debug.LogException(new NotSupportedException(ex2.Message, ex2));
									func2 = null;
								}
								extraData.paraType.selfDrawingMetodo.AddOrReplase(new ValueTuple<Type, string>(type, memberInfo.Name), func2);
							}
						}
					}
					MethodInfo methodInfo2 = memberInfo as MethodInfo;
					if (methodInfo2 != null)
					{
						ParameterInfo[] parameters2 = methodInfo2.GetParameters();
						Type returnType2 = methodInfo2.ReturnType;
						if (parameters2.Length == 0 && returnType2 == typeof(void))
						{
							extraData.paraType.voidMethodInfo.Add(new ValueTuple<Type, string>(type, memberInfo.Name), methodInfo2);
						}
					}
					Attribute[] array = enumerable.Where((Attribute a) => a is SecondaryActionDelegateAttribute).ToArray<Attribute>();
					for (int i = 0; i < array.Length; i++)
					{
						SecondaryActionDelegateAttribute secondaryActionDelegateAttribute = array[i] as SecondaryActionDelegateAttribute;
						if (secondaryActionDelegateAttribute != null)
						{
							string para2 = secondaryActionDelegateAttribute.method;
							MethodInfo methodInfo3 = miembros.FirstOrDefault((MemberInfo m) => m.Name == para2) as MethodInfo;
							if (methodInfo3 != null)
							{
								extraData.paraType.secondaryActions.Add(new ValueTuple<Type, string>(type, memberInfo.Name), methodInfo3);
							}
						}
					}
					Attribute[] array2 = enumerable.Where((Attribute a) => a is IgnoreIfAttribute).ToArray<Attribute>();
					for (int j = 0; j < array2.Length; j++)
					{
						IgnoreIfAttribute ignoreIfAttribute = array2[j] as IgnoreIfAttribute;
						if (ignoreIfAttribute != null)
						{
							string para3 = ignoreIfAttribute.method;
							MethodInfo methodInfo4 = miembros.FirstOrDefault((MemberInfo m) => m.Name == para3) as MethodInfo;
							if (methodInfo4.GetParameters().Length != 0)
							{
								Debug.LogException(new NotSupportedException("metodo debe tener zero parametros. en metodo: " + methodInfo4.Name + " de modelo: " + model.GetType().Name));
							}
							if (methodInfo4.ReturnType != typeof(bool))
							{
								Debug.LogException(new NotSupportedException(string.Concat(new string[]
								{
									"Se necesita Return type tipo :",
									typeof(bool).Name,
									". en metodo: ",
									methodInfo4.Name,
									" de modelo: ",
									model.GetType().Name
								})));
							}
							Func<bool> func3;
							try
							{
								func3 = (Func<bool>)methodInfo4.CreateDelegate(typeof(Func<bool>), model);
							}
							catch (Exception ex3)
							{
								Debug.LogException(new NotSupportedException(ex3.Message, ex3));
								func3 = null;
							}
							if (methodInfo4 != null)
							{
								extraData.paraType.ignoreIf.Add(new ValueTuple<Type, string>(type, memberInfo.Name), func3);
							}
						}
					}
					LabelDinamicoAttribute attribute = this.GetAttribute<LabelDinamicoAttribute>(enumerable);
					if (attribute != null)
					{
						string para4 = attribute.dinamicoMethodTarget;
						MethodInfo methodInfo5 = miembros.FirstOrDefault((MemberInfo m) => m.Name == para4) as MethodInfo;
						if (methodInfo5 != null)
						{
							if (methodInfo5.GetParameters().Length != 0)
							{
								Debug.LogException(new NotSupportedException("metodo debe tener zero parametros. en metodo: " + methodInfo5.Name + " de modelo: " + model.GetType().Name));
							}
							if (methodInfo5.ReturnType != typeof(string))
							{
								Debug.LogException(new NotSupportedException(string.Concat(new string[]
								{
									"Se necesita Return type tipo :",
									typeof(string).Name,
									". en metodo: ",
									methodInfo5.Name,
									" de modelo: ",
									model.GetType().Name
								})));
							}
							LabelDinamicoAttribute.LabelDinamicaHandler labelDinamicaHandler;
							try
							{
								labelDinamicaHandler = (LabelDinamicoAttribute.LabelDinamicaHandler)methodInfo5.CreateDelegate(typeof(LabelDinamicoAttribute.LabelDinamicaHandler), model);
							}
							catch (Exception ex4)
							{
								Debug.LogException(new NotSupportedException(ex4.Message, ex4));
								labelDinamicaHandler = null;
							}
							ValueTuple<Type, string> valueTuple = new ValueTuple<Type, string>(type, memberInfo.Name);
							extraData.paraType.labelDinamicos.Add(valueTuple, labelDinamicaHandler);
						}
					}
					Attribute[] array3 = enumerable.Where((Attribute a) => a is DescripcionDinamicaAttribute).ToArray<Attribute>();
					for (int k = 0; k < array3.Length; k++)
					{
						DescripcionDinamicaAttribute descripcionDinamicaAttribute = array3[k] as DescripcionDinamicaAttribute;
						if (descripcionDinamicaAttribute != null)
						{
							string para = descripcionDinamicaAttribute.dinamicoMethodTarget;
							MethodInfo methodInfo6 = miembros.FirstOrDefault((MemberInfo m) => m.Name == para) as MethodInfo;
							if (methodInfo6 != null)
							{
								if (methodInfo6.GetParameters().Length != 2)
								{
									Debug.LogException(new NotSupportedException("metodo debe tener out de ancho mod y un index. en metodo: " + methodInfo6.Name + " de modelo: " + model.GetType().Name));
								}
								if (methodInfo6.ReturnType != typeof(string))
								{
									Debug.LogException(new NotSupportedException(string.Concat(new string[]
									{
										"Se necesita Return type tipo :",
										typeof(string).Name,
										". en metodo: ",
										methodInfo6.Name,
										" de modelo: ",
										model.GetType().Name
									})));
								}
								DescripcionDinamicaAttribute.DescripcionDinamicaHandler descripcionDinamicaHandler;
								try
								{
									descripcionDinamicaHandler = (DescripcionDinamicaAttribute.DescripcionDinamicaHandler)methodInfo6.CreateDelegate(typeof(DescripcionDinamicaAttribute.DescripcionDinamicaHandler), model);
								}
								catch (Exception ex5)
								{
									Debug.LogException(new NotSupportedException(ex5.Message, ex5));
									descripcionDinamicaHandler = null;
								}
								ValueTuple<Type, string> valueTuple2 = new ValueTuple<Type, string>(type, memberInfo.Name);
								List<DescripcionDinamicaAttribute.DescripcionDinamicaHandler> list4;
								if (!extraData.paraType.descripcionesDinamicas.TryGetValue(valueTuple2, out list4))
								{
									list4 = new List<DescripcionDinamicaAttribute.DescripcionDinamicaHandler>();
									extraData.paraType.descripcionesDinamicas.Add(valueTuple2, list4);
								}
								list4.Add(descripcionDinamicaHandler);
							}
						}
					}
					Attribute[] array4 = enumerable.Where((Attribute a) => a is ActivatedDelegatesAttribute).ToArray<Attribute>();
					for (int l = 0; l < array4.Length; l++)
					{
						ActivatedDelegatesAttribute activatedDelegatesAttribute = array4[l] as ActivatedDelegatesAttribute;
						if (activatedDelegatesAttribute != null)
						{
							string text;
							if (activatedDelegatesAttribute.paraTodos)
							{
								text = "TODOS*TODOS*TODOS";
							}
							else
							{
								text = activatedDelegatesAttribute.para;
							}
							List<Func<bool>> list2;
							if (!extraData.paraType.activatedDelegates.TryGetValue(new ValueTuple<Type, string>(type, text), out list2))
							{
								list2 = new List<Func<bool>>();
								extraData.paraType.activatedDelegates.Add(new ValueTuple<Type, string>(type, text), list2);
							}
							Func<bool> func4;
							if (memberInfo is PropertyInfo)
							{
								PropertyInfo propertyInfo = memberInfo as PropertyInfo;
								func4 = (Func<bool>)Delegate.CreateDelegate(typeof(Func<bool>), model, propertyInfo.GetMethod);
							}
							else if (memberInfo is MethodInfo)
							{
								MethodInfo methodInfo7 = memberInfo as MethodInfo;
								func4 = (Func<bool>)Delegate.CreateDelegate(typeof(Func<bool>), model, methodInfo7);
							}
							else
							{
								func4 = null;
							}
							if (func4 != null)
							{
								list2.Add(func4);
							}
						}
					}
					MethodInfo methodInfo8 = memberInfo as MethodInfo;
					if (methodInfo8 != null)
					{
						ConfirmableListenerAttribute attribute2 = this.GetAttribute<ConfirmableListenerAttribute>(enumerable);
						if (attribute2 != null)
						{
							if (methodInfo8.GetParameters().Length != 1)
							{
								Debug.LogException(new NotSupportedException(string.Concat(new string[]
								{
									"Se necesita string out parametro de Tipo:",
									typeof(string).Name,
									" para Confirmar Listiner. en metodo: ",
									methodInfo8.Name,
									" de modelo: ",
									model.GetType().Name
								})));
							}
							else if (methodInfo8.ReturnType != typeof(bool))
							{
								Debug.LogException(new NotSupportedException(string.Concat(new string[]
								{
									"Se necesita Return type tipo :",
									typeof(bool).Name,
									" para Confirmar Listiner. en metodo: ",
									methodInfo8.Name,
									" de modelo: ",
									model.GetType().Name
								})));
							}
							else
							{
								ConfirmacionHandler confirmacionHandler;
								try
								{
									confirmacionHandler = (ConfirmacionHandler)methodInfo8.CreateDelegate(typeof(ConfirmacionHandler), model);
								}
								catch (Exception ex6)
								{
									Debug.LogException(new NotSupportedException(ex6.Message, ex6));
									confirmacionHandler = null;
								}
								extraData.paraType.confirmables.AddOrReplase(new ValueTuple<Type, string>(type, attribute2.member), confirmacionHandler);
							}
						}
					}
				}
			}
			if (extraData.paraModel.modelAdded.Add(model))
			{
				foreach (MemberInfo memberInfo2 in miembros)
				{
					IEnumerable<Attribute> enumerable2 = memberInfo2.GetCustomAttributes();
					enumerable2 = extraData.overrides.Concat(enumerable2, model, memberInfo2.Name, -1);
					Attribute[] array5 = enumerable2.Where((Attribute a) => a is ModeloExtraDataAttribute).ToArray<Attribute>();
					for (int n = 0; n < array5.Length; n++)
					{
						ModeloExtraDataAttribute modeloExtraDataAttribute = array5[n] as ModeloExtraDataAttribute;
						if (modeloExtraDataAttribute != null)
						{
							string text2;
							if (modeloExtraDataAttribute.paraTodos)
							{
								text2 = "TODOS*TODOS*TODOS";
							}
							else
							{
								text2 = modeloExtraDataAttribute.para;
							}
							List<Func<object>> list3;
							if (!extraData.paraModel.dataDelegates.TryGetValue(new ValueTuple<object, string>(model, text2), out list3))
							{
								list3 = new List<Func<object>>();
								extraData.paraModel.dataDelegates.Add(new ValueTuple<object, string>(model, text2), list3);
							}
							PropertyInfo propertyInfo2 = memberInfo2 as PropertyInfo;
							Func<object> func5;
							if (propertyInfo2 != null)
							{
								if (propertyInfo2.PropertyType == typeof(string))
								{
									Func<string> getter2 = (Func<string>)Delegate.CreateDelegate(typeof(Func<string>), model, propertyInfo2.GetMethod);
									func5 = () => getter2();
								}
								if (propertyInfo2.PropertyType == typeof(int))
								{
									Func<int> getter3 = (Func<int>)Delegate.CreateDelegate(typeof(Func<int>), model, propertyInfo2.GetMethod);
									func5 = () => getter3();
								}
								if (propertyInfo2.PropertyType == typeof(bool))
								{
									Func<bool> getter = (Func<bool>)Delegate.CreateDelegate(typeof(Func<bool>), model, propertyInfo2.GetMethod);
									func5 = () => getter();
								}
								else
								{
									func5 = (Func<object>)Delegate.CreateDelegate(typeof(Func<object>), model, propertyInfo2.GetMethod);
								}
							}
							else
							{
								func5 = null;
							}
							if (func5 != null)
							{
								list3.Add(func5);
							}
						}
					}
				}
			}
		}

		// Token: 0x060003A8 RID: 936 RVA: 0x0000C6A8 File Offset: 0x0000A8A8
		private void setAtributosAPanel(IUIPanel panel, IEnumerable<Attribute> atributes)
		{
			PanelLayoutAttribute panelLayoutAttribute = (PanelLayoutAttribute)atributes.FirstOrDefault((Attribute a) => a is PanelLayoutAttribute);
			if (panelLayoutAttribute != null)
			{
				LayoutElement componentNotNull = panel.transform.GetComponentNotNull<LayoutElement>();
				if (panelLayoutAttribute.alturaMinimaUsing)
				{
					componentNotNull.minHeight = panelLayoutAttribute.alturaMinima;
				}
				if (panelLayoutAttribute.alturaPreferidaUsing)
				{
					componentNotNull.preferredHeight = panelLayoutAttribute.alturaPreferida;
				}
			}
		}

		// Token: 0x060003A9 RID: 937 RVA: 0x0000C718 File Offset: 0x0000A918
		private bool addTitleOld(IUIPanel instanciado, Type tipoModel, FieldInfo fieldInfoInParentModel, object modelOwner, IEnumerable<Attribute> atributes, DibujadorDynamico.ExtraData extradata)
		{
			IUIPanelConTitulo iuipanelConTitulo = instanciado as IUIPanelConTitulo;
			if (iuipanelConTitulo == null || iuipanelConTitulo.padreParaTitulos == null)
			{
				return false;
			}
			if (this.GetAttribute<UnTittleAttribute>(atributes) != null)
			{
				return false;
			}
			TextoLocalizadoAttribute currentLocalizationOrDefault = this.GetCurrentLocalizationOrDefault<LabelAttribute>(atributes, tipoModel.Name, "US");
			if (currentLocalizationOrDefault != null && !string.IsNullOrWhiteSpace(currentLocalizationOrDefault.text))
			{
				TituloElement tituloElement = Object.Instantiate<TituloElement>(MapaSingleton<MapaSingletonDeUIPrefabs>.instance.titulo);
				IFontAttribute fontAttribute = this.TryGetAttributeFirst<IFontAttribute>(atributes);
				IBaseLayoutAttribute baseLayoutAttribute = this.TryGetAttributeLast<IBaseLayoutAttribute>(atributes);
				this.addUIElementoAPanel(iuipanelConTitulo.padreParaTitulos, tituloElement, false);
				DibujadorDynamico.SetUIText(tituloElement.text, currentLocalizationOrDefault);
				DibujadorDynamico.SetUILabelAtributosToFont(tituloElement, tituloElement.text, fontAttribute, baseLayoutAttribute);
				this.addDescripcionSimple(tituloElement, fieldInfoInParentModel, modelOwner, -1, atributes, extradata);
				return true;
			}
			return false;
		}

		// Token: 0x060003AA RID: 938 RVA: 0x0000C7D0 File Offset: 0x0000A9D0
		private bool addDynamicTitle(object model, IUIPanel instanciado, Type tipoModel, FieldInfo fieldInfoInParentModel, object modelOwner, IEnumerable<Attribute> atributes, IReadOnlyList<MemberInfo> miembros, DibujadorDynamico.ExtraData extradata)
		{
			IUIPanelConTitulo iuipanelConTitulo = instanciado as IUIPanelConTitulo;
			if (iuipanelConTitulo == null || iuipanelConTitulo.padreParaTitulos == null)
			{
				return false;
			}
			if (this.GetAttribute<UnTittleAttribute>(atributes) != null)
			{
				return false;
			}
			LabelDinamicoAttribute attribute = this.GetAttribute<LabelDinamicoAttribute>(atributes);
			if (attribute != null)
			{
				string para = attribute.dinamicoMethodTarget;
				MethodInfo methodInfo = miembros.FirstOrDefault((MemberInfo m) => m.Name == para) as MethodInfo;
				if (methodInfo != null)
				{
					if (methodInfo.GetParameters().Length != 0)
					{
						Debug.LogException(new NotSupportedException("metodo debe tener zero parametros. en metodo: " + methodInfo.Name + " de modelo: " + tipoModel.Name));
					}
					if (methodInfo.ReturnType != typeof(string))
					{
						Debug.LogException(new NotSupportedException(string.Concat(new string[]
						{
							"Se necesita Return type tipo :",
							typeof(string).Name,
							". en metodo: ",
							methodInfo.Name,
							" de modelo: ",
							tipoModel.Name
						})));
					}
					LabelDinamicoAttribute.LabelDinamicaHandler labelDinamicaHandler;
					try
					{
						labelDinamicaHandler = (LabelDinamicoAttribute.LabelDinamicaHandler)methodInfo.CreateDelegate(typeof(LabelDinamicoAttribute.LabelDinamicaHandler), model);
					}
					catch (Exception ex)
					{
						Debug.LogException(new NotSupportedException(ex.Message, ex));
						labelDinamicaHandler = null;
						return false;
					}
					string text = labelDinamicaHandler();
					if (!string.IsNullOrWhiteSpace(text))
					{
						TituloElement tituloElement = Object.Instantiate<TituloElement>(MapaSingleton<MapaSingletonDeUIPrefabs>.instance.titulo);
						IFontAttribute fontAttribute = this.TryGetAttributeFirst<IFontAttribute>(atributes);
						IBaseLayoutAttribute baseLayoutAttribute = this.TryGetAttributeLast<IBaseLayoutAttribute>(atributes);
						this.addUIElementoAPanel(iuipanelConTitulo.padreParaTitulos, tituloElement, false);
						tituloElement.text.text = text;
						DibujadorDynamico.SetUILabelAtributosToFont(tituloElement, tituloElement.text, fontAttribute, baseLayoutAttribute);
						this.addDescripcionSimple(tituloElement, fieldInfoInParentModel, modelOwner, -1, atributes, extradata);
						return true;
					}
					return false;
				}
			}
			return false;
		}

		// Token: 0x060003AB RID: 939 RVA: 0x0000C9A4 File Offset: 0x0000ABA4
		private bool addTitle(IUIPanel instanciado, Type tipoModel, FieldInfo fieldInfoInParentModel, object modelOwner, IEnumerable<Attribute> atributes, DibujadorDynamico.ExtraData extradata)
		{
			IUIPanelConTitulo iuipanelConTitulo = instanciado as IUIPanelConTitulo;
			if (iuipanelConTitulo == null || iuipanelConTitulo.padreParaTitulos == null)
			{
				return false;
			}
			if (this.GetAttribute<UnTittleAttribute>(atributes) != null)
			{
				return false;
			}
			TextoLocalizadoAttribute currentLocalization = this.GetCurrentLocalization<LabelLocalizadoAttribute>(atributes);
			if (currentLocalization != null && !string.IsNullOrWhiteSpace(currentLocalization.text))
			{
				TituloElement tituloElement = Object.Instantiate<TituloElement>(MapaSingleton<MapaSingletonDeUIPrefabs>.instance.titulo);
				IFontAttribute fontAttribute = this.TryGetAttributeFirst<IFontAttribute>(atributes);
				IBaseLayoutAttribute baseLayoutAttribute = this.TryGetAttributeLast<IBaseLayoutAttribute>(atributes);
				this.addUIElementoAPanel(iuipanelConTitulo.padreParaTitulos, tituloElement, false);
				DibujadorDynamico.SetUIText(tituloElement.text, currentLocalization);
				DibujadorDynamico.SetUILabelAtributosToFont(tituloElement, tituloElement.text, fontAttribute, baseLayoutAttribute);
				this.addDescripcionSimple(tituloElement, fieldInfoInParentModel, modelOwner, -1, atributes, extradata);
				return true;
			}
			return false;
		}

		// Token: 0x060003AC RID: 940 RVA: 0x0000CA50 File Offset: 0x0000AC50
		private void addUIElementoAPanel(IUIPanel panel, IUIElemento elemento, IEnumerable<Attribute> atributesDeElemento, IElementLayoutAttribute overrideingLayout, bool insert = false)
		{
			IElementLayoutAttribute elementLayoutAttribute = overrideingLayout ?? this.GetAttribute<IElementLayoutAttribute>(atributesDeElemento);
			ParentPanelTargetAttribute attribute = this.GetAttribute<ParentPanelTargetAttribute>(atributesDeElemento);
			int valueOrDefault = ((attribute != null) ? new int?(attribute.index) : null).GetValueOrDefault();
			Transform parentPara = panel.GetParentPara(valueOrDefault);
			SeparadorAttribute attribute2 = this.GetAttribute<SeparadorAttribute>(atributesDeElemento);
			if (attribute2 != null)
			{
				GameObject gameObject = Object.Instantiate<GameObject>(MapaSingleton<MapaSingletonDeUIPrefabs>.instance.separador);
				if (attribute2.heightByUser)
				{
					LayoutElement component = gameObject.GetComponent<LayoutElement>();
					if (component != null)
					{
						component.preferredHeight = (float)attribute2.height;
						component.minHeight = (float)attribute2.height;
					}
				}
				gameObject.transform.SetParent(parentPara, false);
			}
			EspacioAttribute attribute3 = this.GetAttribute<EspacioAttribute>(atributesDeElemento);
			if (attribute3 != null)
			{
				GameObject gameObject2 = Object.Instantiate<GameObject>(MapaSingleton<MapaSingletonDeUIPrefabs>.instance.espacio);
				if (attribute3.heightByUser)
				{
					LayoutElement component2 = gameObject2.GetComponent<LayoutElement>();
					if (component2 != null)
					{
						component2.preferredHeight = (float)attribute3.height;
					}
				}
				gameObject2.transform.SetParent(parentPara, false);
			}
			this.addUIElementoAPanel(parentPara, elemento, insert);
			this.setSize(elementLayoutAttribute, parentPara, null, null, null);
			ScrollRect componentInParent = parentPara.GetComponentInParent<ScrollRect>();
			if (componentInParent != null)
			{
				componentInParent.enabled = true;
			}
		}

		// Token: 0x060003AD RID: 941 RVA: 0x0000CB85 File Offset: 0x0000AD85
		private void addUIElementoAPanel(Transform panel, IUIElemento elemento, bool insert = false)
		{
			elemento.transform.SetParent(panel, false);
			if (insert)
			{
				elemento.transform.SetSiblingIndex(0);
			}
		}

		// Token: 0x060003AE RID: 942 RVA: 0x0000CBA4 File Offset: 0x0000ADA4
		public void SetControlesAPanel(IUIPanel panel, object model, DibujadorDynamico.ExtraData extradata, UnityAction destruir = null, UnityAction hide = null)
		{
			if (model == null)
			{
				return;
			}
			Type type = model.GetType();
			bool flag = false;
			IEnumerable<Attribute> enumerable = type.GetCustomAttributes();
			if (extradata != null)
			{
				enumerable = extradata.overrides.Concat(enumerable, model, null, -1);
			}
			IUIPanelConControles iuipanelConControles = panel as IUIPanelConControles;
			if (iuipanelConControles != null)
			{
				HelpPanelControlAttribute attribute = this.GetAttribute<HelpPanelControlAttribute>(enumerable);
				MethodInfo methodInfo;
				if (attribute != null && extradata.paraType.voidMethodInfo.TryGetValue(new ValueTuple<Type, string>(type, attribute.listiner), out methodInfo))
				{
					flag = true;
					BotonElement botonElement = Object.Instantiate<BotonElement>(MapaSingleton<MapaSingletonDeUIPrefabs>.instance.controlBoton);
					this.addUIElementoAPanel(iuipanelConControles.padreParaControles, botonElement, false);
					botonElement.label.text = "?";
					UnityAction unityAction;
					try
					{
						unityAction = (UnityAction)methodInfo.CreateDelegate(typeof(UnityAction), model);
					}
					catch (Exception ex)
					{
						Debug.LogException(new NotSupportedException(ex.Message, ex));
						unityAction = null;
					}
					botonElement.onClicked.AddListener(unityAction);
				}
				IconPanelControlAttribute attribute2 = this.GetAttribute<IconPanelControlAttribute>(enumerable);
				MethodInfo methodInfo2;
				if (attribute2 != null && extradata.paraType.voidMethodInfo.TryGetValue(new ValueTuple<Type, string>(type, attribute2.listiner), out methodInfo2))
				{
					flag = true;
					BotonIconElementConToolTip botonIconElementConToolTip = Object.Instantiate<BotonIconElementConToolTip>(MapaSingleton<MapaSingletonDeUIPrefabs>.instance.controlBotonIconToolTip);
					this.addUIElementoAPanel(iuipanelConControles.padreParaControles, botonIconElementConToolTip, false);
					botonIconElementConToolTip.tooltip.infoLeft = attribute2.toolTip;
					UnityAction unityAction2;
					try
					{
						unityAction2 = (UnityAction)methodInfo2.CreateDelegate(typeof(UnityAction), model);
					}
					catch (Exception ex2)
					{
						Debug.LogException(new NotSupportedException(ex2.Message, ex2));
						unityAction2 = null;
					}
					botonIconElementConToolTip.onClicked.AddListener(unityAction2);
				}
				CerrableAttribute attribute3 = this.GetAttribute<CerrableAttribute>(enumerable);
				if (attribute3 != null && hide != null && destruir != null)
				{
					flag = true;
					BotonElement botonElement2 = Object.Instantiate<BotonElement>(MapaSingleton<MapaSingletonDeUIPrefabs>.instance.controlBoton);
					this.addUIElementoAPanel(iuipanelConControles.padreParaControles, botonElement2, false);
					botonElement2.label.text = "X";
					CerrableAttribute.Accion accion = attribute3.accion;
					if (accion != CerrableAttribute.Accion.destruir)
					{
						if (accion != CerrableAttribute.Accion.ocultar)
						{
							throw new ArgumentOutOfRangeException(attribute3.accion.ToString());
						}
						botonElement2.onClicked.AddListener(hide);
					}
					else
					{
						botonElement2.onClicked.AddListener(destruir);
					}
				}
				if (!flag)
				{
					iuipanelConControles.padreParaControles.gameObject.SetActive(false);
				}
				else
				{
					iuipanelConControles.padreParaControles.gameObject.SetActive(true);
				}
				IUIPanelConSuperiorPanel iuipanelConSuperiorPanel = panel as IUIPanelConSuperiorPanel;
				if (iuipanelConSuperiorPanel != null)
				{
					iuipanelConSuperiorPanel.CheckIsVisible();
				}
			}
			foreach (IUIElemento iuielemento in panel.elementoPorModelo.Values.Where((IUIElemento el) => el is IUIPanel))
			{
				MemberInfo memberInfo = type.GetMember(iuielemento.modelName).FirstOrDefault<MemberInfo>();
				if (!(memberInfo == null))
				{
					object obj;
					if (memberInfo is FieldInfo)
					{
						obj = ((FieldInfo)memberInfo).GetValue(model);
					}
					else if (memberInfo is PropertyInfo)
					{
						obj = ((PropertyInfo)memberInfo).GetValue(model);
					}
					else
					{
						obj = null;
					}
					if (obj != null)
					{
						if (DibujadorDynamico.IsList(memberInfo))
						{
							IList list = obj as IList;
							if (list == null)
							{
								continue;
							}
							if (list.ContieneIndexBase(iuielemento.modelItemIndex))
							{
								obj = list[iuielemento.modelItemIndex];
							}
						}
						this.SetControlesAPanel((IUIPanel)iuielemento, obj, extradata, null, null);
					}
				}
			}
		}

		// Token: 0x060003AF RID: 943 RVA: 0x0000CF38 File Offset: 0x0000B138
		public void SetValoresAPanel(IUIPanel panel, object model, bool silenced)
		{
			this.setValoresAPanel(panel, model, silenced);
		}

		// Token: 0x060003B0 RID: 944 RVA: 0x0000CF43 File Offset: 0x0000B143
		public object SetValoresAModelo(object model, IUIPanel panel)
		{
			return this.setValoresAModelo(model, panel);
		}

		// Token: 0x060003B1 RID: 945 RVA: 0x0000CF50 File Offset: 0x0000B150
		private void setValoresAPanel(IUIPanel panel, object model, bool silenced)
		{
			if (model == null)
			{
				return;
			}
			if (panel == null)
			{
				return;
			}
			if (!panel.isBinded)
			{
				return;
			}
			List<IUIElementoConValor> list = new List<IUIElementoConValor>();
			List<IUIPanel> list2 = new List<IUIPanel>();
			foreach (object obj in panel.GetParentPara(0))
			{
				Transform transform = (Transform)obj;
				IUIElementoConValor component = transform.GetComponent<IUIElementoConValor>();
				if (component != null)
				{
					list.Add(component);
				}
				IUIPanel component2 = transform.GetComponent<IUIPanel>();
				if (component2 != null)
				{
					list2.Add(component2);
				}
			}
			foreach (IUIElementoConValor iuielementoConValor in list)
			{
				this.SetValueAElementoDesdeModelo(iuielementoConValor, model, silenced);
			}
			foreach (IUIPanel iuipanel in list2)
			{
				FieldInfo fieldInfo;
				if (model == null)
				{
					fieldInfo = null;
				}
				else
				{
					Type type = model.GetType();
					fieldInfo = ((type != null) ? type.GetField(iuipanel.modelName, BindingFlags.Instance | BindingFlags.Public | BindingFlags.FlattenHierarchy) : null);
				}
				FieldInfo fieldInfo2 = fieldInfo;
				if (!(fieldInfo2 == null))
				{
					object obj2 = fieldInfo2.GetValue(model);
					if (obj2 == null)
					{
						obj2 = Activator.CreateInstance(iuipanel.modelType);
						fieldInfo2.SetValue(model, obj2);
					}
					this.setValoresAPanel(iuipanel, obj2, silenced);
				}
			}
		}

		// Token: 0x060003B2 RID: 946 RVA: 0x0000D0C0 File Offset: 0x0000B2C0
		private object setValoresAModelo(object model, IUIPanel panel)
		{
			if (model == null)
			{
				return null;
			}
			if (panel == null)
			{
				return null;
			}
			if (!panel.isBinded)
			{
				return null;
			}
			List<IUIElementoConValor> list = new List<IUIElementoConValor>();
			List<IUIPanel> list2 = new List<IUIPanel>();
			foreach (object obj in panel.GetParentPara(0))
			{
				Transform transform = (Transform)obj;
				IUIElementoConValor component = transform.GetComponent<IUIElementoConValor>();
				if (component != null)
				{
					list.Add(component);
				}
				IUIPanel component2 = transform.GetComponent<IUIPanel>();
				if (component2 != null)
				{
					list2.Add(component2);
				}
			}
			foreach (IUIElementoConValor iuielementoConValor in list)
			{
				this.SetValueAModeloDesdeElemento(model, iuielementoConValor);
			}
			foreach (IUIPanel iuipanel in list2)
			{
				FieldInfo fieldInfo;
				if (model == null)
				{
					fieldInfo = null;
				}
				else
				{
					Type type = model.GetType();
					fieldInfo = ((type != null) ? type.GetField(iuipanel.modelName, BindingFlags.Instance | BindingFlags.Public | BindingFlags.FlattenHierarchy) : null);
				}
				FieldInfo fieldInfo2 = fieldInfo;
				if (!(fieldInfo2 == null))
				{
					object obj2 = fieldInfo2.GetValue(model);
					if (obj2 == null)
					{
						obj2 = Activator.CreateInstance(iuipanel.modelType);
					}
					object obj3 = this.setValoresAModelo(obj2, iuipanel);
					fieldInfo2.SetValue(model, obj3);
				}
			}
			return model;
		}

		// Token: 0x060003B3 RID: 947 RVA: 0x0000D234 File Offset: 0x0000B434
		public List<BotonElementBase> AddBotones(object buttonModel, IUIPanel panel, ref DibujadorDynamico.ExtraData extraData)
		{
			IUIPanelConBotones iuipanelConBotones = panel as IUIPanelConBotones;
			List<BotonElementBase> list = new List<BotonElementBase>();
			Type type = buttonModel.GetType();
			if (iuipanelConBotones != null)
			{
				if (iuipanelConBotones.padreParaBotones == null)
				{
					throw new ArgumentNullException("target.panelParaBotones", "target.panelParaBotones null reference.");
				}
				if (buttonModel == null)
				{
					return null;
				}
				Dictionary<string, IUIElemento> dictionary = new Dictionary<string, IUIElemento>();
				MemberInfo[] array = (from m in type.GetMembers(BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.FlattenHierarchy)
					where m is MethodInfo || m is PropertyInfo
					select m).ToArray<MemberInfo>();
				this.LoadExtraData(array, buttonModel, ref extraData);
				foreach (MemberInfo memberInfo in array)
				{
					MethodInfo methodInfo = memberInfo as MethodInfo;
					Func<bool> func;
					if (!(methodInfo == null) && (!extraData.paraType.ignoreIf.TryGetValue(new ValueTuple<Type, string>(type, memberInfo.Name), out func) || !((func != null) ? new bool?(func()) : null).GetValueOrDefault()))
					{
						BotonElementBase botonElementBase = null;
						if (memberInfo.IsDefined(typeof(BotonDePanelAttribute), true))
						{
							IEnumerable<Attribute> customAttributes = memberInfo.GetCustomAttributes();
							botonElementBase = this.DibujarBotonDePanel(methodInfo, buttonModel, iuipanelConBotones, iuipanelConBotones.padreParaBotones, customAttributes, extraData);
						}
						if (memberInfo.IsDefined(typeof(BotonDePanelConfirmableAttribute), true))
						{
							IEnumerable<Attribute> customAttributes2 = memberInfo.GetCustomAttributes();
							botonElementBase = this.DibujarBotonDePanelConfirmable(methodInfo, buttonModel, iuipanelConBotones, iuipanelConBotones.padreParaBotones, customAttributes2, extraData);
						}
						if (botonElementBase != null)
						{
							list.Add(botonElementBase);
							dictionary.Add(memberInfo.Name, botonElementBase);
						}
					}
				}
				foreach (MemberInfo memberInfo2 in array)
				{
					IUIElemento iuielemento;
					if (dictionary.TryGetValue(memberInfo2.Name, out iuielemento))
					{
						IEnumerable<Attribute> customAttributes3 = memberInfo2.GetCustomAttributes();
						bool flag = memberInfo2.IsDefined(typeof(IgnoreValueAttribute));
						this.BindElemento(iuipanelConBotones, iuielemento, memberInfo2, memberInfo2.Name, null, buttonModel, flag, false, customAttributes3);
					}
				}
				if (list.Count == 0)
				{
					iuipanelConBotones.padreParaBotones.gameObject.SetActive(false);
				}
				else
				{
					iuipanelConBotones.padreParaBotones.gameObject.SetActive(true);
					iuipanelConBotones.AddBotones(dictionary);
					dictionary.ForEach(delegate(KeyValuePair<string, IUIElemento> par)
					{
						par.Value.AddedTo(panel.transform);
					});
				}
			}
			foreach (IUIElemento iuielemento2 in panel.elementoPorModelo.Values.Where((IUIElemento el) => el is IUIPanel))
			{
				MemberInfo memberInfo3 = type.GetMember(iuielemento2.modelName).FirstOrDefault<MemberInfo>();
				if (!(memberInfo3 == null))
				{
					object obj;
					if (memberInfo3 is FieldInfo)
					{
						obj = ((FieldInfo)memberInfo3).GetValue(buttonModel);
					}
					else if (memberInfo3 is PropertyInfo)
					{
						obj = ((PropertyInfo)memberInfo3).GetValue(buttonModel);
					}
					else
					{
						obj = null;
					}
					if (obj != null)
					{
						this.AddBotones(obj, (IUIPanel)iuielemento2, ref extraData);
					}
				}
			}
			return list;
		}

		// Token: 0x060003B4 RID: 948 RVA: 0x0000D56C File Offset: 0x0000B76C
		public void HideBotonesDePanel(IUIPanel target)
		{
			IUIPanelConBotones iuipanelConBotones = target as IUIPanelConBotones;
			if (iuipanelConBotones == null)
			{
				return;
			}
			iuipanelConBotones.padreParaBotones.gameObject.SetActive(false);
		}

		// Token: 0x060003B5 RID: 949 RVA: 0x0000D598 File Offset: 0x0000B798
		public void HideControlesDePanel(IUIPanel target)
		{
			IUIPanelConControles iuipanelConControles = target as IUIPanelConControles;
			if (iuipanelConControles == null)
			{
				return;
			}
			iuipanelConControles.padreParaControles.gameObject.SetActive(false);
		}

		// Token: 0x060003B6 RID: 950 RVA: 0x0000D5C4 File Offset: 0x0000B7C4
		private static void SetDelegadoAModelChanged(IEnumerable<IUIElemento> elementos, MethodInfo info, IUIPanel panel, object modelOwner, IEnumerable<IUIElemento> extraElements = null)
		{
			try
			{
				if (elementos != null)
				{
					foreach (IUIElemento iuielemento in elementos)
					{
						if (iuielemento != null && DibujadorDynamico.m_elementosTEMP.Add(iuielemento))
						{
							DibujadorDynamico.SetDelegadoAElementoConValor(iuielemento, info, panel, modelOwner);
						}
					}
				}
				if (extraElements != null)
				{
					foreach (IUIElemento iuielemento2 in extraElements)
					{
						if (iuielemento2 != null && DibujadorDynamico.m_elementosTEMP.Add(iuielemento2))
						{
							DibujadorDynamico.SetDelegadoAElementoConValor(iuielemento2, info, panel, modelOwner);
						}
					}
				}
			}
			finally
			{
				DibujadorDynamico.m_elementosTEMP.Clear();
			}
		}

		// Token: 0x060003B7 RID: 951 RVA: 0x0000D688 File Offset: 0x0000B888
		private static void SetDelegadoAElementoConValor(IUIElemento elemento, MethodInfo info, IUIPanel panel, object modelOwner)
		{
			IUIElementoConValor iuielementoConValor = elemento as IUIElementoConValor;
			if (iuielementoConValor == null)
			{
				return;
			}
			ParameterInfo[] parameters = info.GetParameters();
			if (parameters.Length != 1)
			{
				Debug.LogException(new NotSupportedException(string.Concat(new string[]
				{
					"Se necesita un parametro de Tipo:",
					typeof(IUIElementoConValor).Name,
					" para OnValueChanged Listiner. en metodo: ",
					info.Name,
					" de modelo: ",
					modelOwner.GetType().Name
				})), panel as Object);
				return;
			}
			ParameterInfo parameterInfo = parameters.FirstOrDefault<ParameterInfo>();
			if (parameterInfo == null || parameterInfo.ParameterType != typeof(IUIElementoConValor))
			{
				Debug.LogException(new NotSupportedException(string.Concat(new string[]
				{
					"Se necesita un parametro de tipo: ",
					typeof(IUIElementoConValor).Name,
					". en metodo: ",
					info.Name,
					" de modelo: ",
					modelOwner.GetType().Name
				})), panel as Object);
				return;
			}
			UnityAction<IUIElementoConValor> unityAction;
			try
			{
				unityAction = (UnityAction<IUIElementoConValor>)info.CreateDelegate(typeof(UnityAction<IUIElementoConValor>), modelOwner);
			}
			catch (Exception ex)
			{
				Debug.LogException(new NotSupportedException(ex.Message, ex), panel as Object);
				return;
			}
			if (iuielementoConValor.onValueChanged != null)
			{
				iuielementoConValor.onValueChanged.AddListener(unityAction);
			}
		}

		// Token: 0x060003B8 RID: 952 RVA: 0x0000D7E4 File Offset: 0x0000B9E4
		private void SetDelegadoAElementoConfirmable(IUIElemento elemento, MethodInfo info, IUIPanel panel, object modelOwner)
		{
			throw new NotImplementedException();
		}

		// Token: 0x060003B9 RID: 953 RVA: 0x0000D7EC File Offset: 0x0000B9EC
		private static void SetDelegadoAClickable(IUIBoton clickable, MethodInfo info, IUIPanel panel, object modelOwner)
		{
			if (info == null)
			{
				return;
			}
			if (info.GetParameters().Length != 0)
			{
				Debug.LogException(new NotSupportedException("No debe tener parametros. en metodo: " + info.Name + " de modelo: " + modelOwner.GetType().Name), panel as Object);
				return;
			}
			if (info.ReturnType != typeof(void))
			{
				Debug.LogException(new NotSupportedException("No debe tener return type diferente a void"), panel as Object);
				return;
			}
			UnityAction unityAction;
			try
			{
				unityAction = (UnityAction)info.CreateDelegate(typeof(UnityAction), modelOwner);
			}
			catch (Exception ex)
			{
				Debug.LogException(new NotSupportedException(ex.Message, ex), panel as Object);
				return;
			}
			clickable.onClicked.AddListener(unityAction);
		}

		// Token: 0x060003BA RID: 954 RVA: 0x0000D8BC File Offset: 0x0000BABC
		private static void SetDelegadoAConfirmableConElemento(IUIElemento elemento, MethodInfo info, IUIPanel panel, object modelOwner)
		{
			IUIBoton iuiboton = elemento as IUIBoton;
			if (iuiboton == null)
			{
				return;
			}
			if (info == null)
			{
				return;
			}
			ParameterInfo[] parameters = info.GetParameters();
			if (parameters.Length != 1)
			{
				Debug.LogException(new NotSupportedException(string.Concat(new string[]
				{
					"Se necesita un parametro de Tipo:",
					typeof(IUIBoton).Name,
					" para OnClicked Listiner. en metodo: ",
					info.Name,
					" de modelo: ",
					modelOwner.GetType().Name
				})), panel as Object);
				return;
			}
			if (info.ReturnType != typeof(void))
			{
				Debug.LogException(new NotSupportedException("No debe tener return type diferente a void"), panel as Object);
				return;
			}
			ParameterInfo parameterInfo = parameters.FirstOrDefault<ParameterInfo>();
			if (parameterInfo == null || parameterInfo.ParameterType != typeof(IUIBoton))
			{
				Debug.LogException(new NotSupportedException(string.Concat(new string[]
				{
					"Se necesita un parametro de tipo: ",
					typeof(IUIBoton).Name,
					". en metodo: ",
					info.Name,
					" de modelo: ",
					modelOwner.GetType().Name
				})), panel as Object);
				return;
			}
			UnityAction<IUIBoton> unityAction;
			try
			{
				unityAction = (UnityAction<IUIBoton>)info.CreateDelegate(typeof(UnityAction<IUIBoton>), modelOwner);
			}
			catch (Exception ex)
			{
				Debug.LogException(new NotSupportedException(ex.Message, ex), panel as Object);
				return;
			}
			iuiboton.onClickedElement.AddListener(unityAction);
		}

		// Token: 0x060003BB RID: 955 RVA: 0x0000DA48 File Offset: 0x0000BC48
		private static void SetDelegadoAClickableConElemento(IUIElemento elemento, MethodInfo info, IUIPanel panel, object modelOwner)
		{
			IUIElementoClickable iuielementoClickable = elemento as IUIElementoClickable;
			if (iuielementoClickable == null)
			{
				return;
			}
			if (info == null)
			{
				return;
			}
			ParameterInfo[] parameters = info.GetParameters();
			if (parameters.Length != 1)
			{
				Debug.LogException(new NotSupportedException(string.Concat(new string[]
				{
					"Se necesita un parametro de Tipo:",
					typeof(IUIElementoClickable).Name,
					" para OnClicked Listiner. en metodo: ",
					info.Name,
					" de modelo: ",
					modelOwner.GetType().Name
				})), panel as Object);
				return;
			}
			if (info.ReturnType != typeof(void))
			{
				Debug.LogException(new NotSupportedException("No debe tener return type diferente a void"), panel as Object);
				return;
			}
			ParameterInfo parameterInfo = parameters.FirstOrDefault<ParameterInfo>();
			if (parameterInfo == null || parameterInfo.ParameterType != typeof(IUIElementoClickable))
			{
				Debug.LogException(new NotSupportedException(string.Concat(new string[]
				{
					"Se necesita un parametro de tipo: ",
					typeof(IUIElementoClickable).Name,
					". en metodo: ",
					info.Name,
					" de modelo: ",
					modelOwner.GetType().Name
				})), panel as Object);
				return;
			}
			UnityAction<IUIElementoClickable> unityAction;
			try
			{
				unityAction = (UnityAction<IUIElementoClickable>)info.CreateDelegate(typeof(UnityAction<IUIElementoClickable>), modelOwner);
			}
			catch (Exception ex)
			{
				Debug.LogException(new NotSupportedException(ex.Message, ex), panel as Object);
				return;
			}
			iuielementoClickable.onElementoClicked.AddListener(unityAction);
		}

		// Token: 0x060003BC RID: 956 RVA: 0x0000DBD4 File Offset: 0x0000BDD4
		private static void SetDelegadoAPanel(MethodInfo info, IUIPanel panel, object modelOwner)
		{
			IUIPanelConEventos iuipanelConEventos = panel as IUIPanelConEventos;
			if (iuipanelConEventos == null)
			{
				return;
			}
			if (info == null)
			{
				return;
			}
			ParameterInfo[] parameters = info.GetParameters();
			if (parameters.Length != 3)
			{
				Debug.LogException(new NotSupportedException(string.Concat(new string[]
				{
					"Se necesitan 3 parametros de Tipo:",
					typeof(string).Name,
					" ",
					typeof(object).Name,
					" ",
					typeof(IUIPanelConEventos).Name,
					" para Panel Listiner. en metodo: ",
					info.Name,
					" de modelo: ",
					modelOwner.GetType().Name
				})), panel as Object);
				return;
			}
			if (info.ReturnType != typeof(void))
			{
				Debug.LogException(new NotSupportedException("No debe tener return type diferente a void"), panel as Object);
				return;
			}
			ParameterInfo parameterInfo = parameters.FirstOrDefault<ParameterInfo>();
			if (parameterInfo == null || parameterInfo.ParameterType != typeof(string))
			{
				Debug.LogException(new NotSupportedException(string.Concat(new string[]
				{
					"Se necesita un parametro de tipo: ",
					typeof(string).Name,
					" de primero en metodo: ",
					info.Name,
					" de modelo: ",
					modelOwner.GetType().Name
				})), panel as Object);
				return;
			}
			ParameterInfo parameterInfo2 = parameters.ElementAtOrDefault(1);
			if (parameterInfo2 == null || parameterInfo2.ParameterType != typeof(object))
			{
				Debug.LogException(new NotSupportedException(string.Concat(new string[]
				{
					"Se necesita un parametro de tipo: ",
					typeof(object).Name,
					" de primero en metodo: ",
					info.Name,
					" de modelo: ",
					modelOwner.GetType().Name
				})), panel as Object);
				return;
			}
			ParameterInfo parameterInfo3 = parameters.ElementAtOrDefault(2);
			if (parameterInfo3 == null || parameterInfo3.ParameterType != typeof(IUIPanelConEventos))
			{
				Debug.LogException(new NotSupportedException(string.Concat(new string[]
				{
					"Se necesita un parametro de tipo: ",
					typeof(IUIPanelConEventos).Name,
					" de primero en metodo: ",
					info.Name,
					" de modelo: ",
					modelOwner.GetType().Name
				})), panel as Object);
				return;
			}
			UnityAction<string, object, IUIPanelConEventos> unityAction;
			try
			{
				unityAction = (UnityAction<string, object, IUIPanelConEventos>)info.CreateDelegate(typeof(UnityAction<string, object, IUIPanelConEventos>), modelOwner);
			}
			catch (Exception ex)
			{
				Debug.LogException(new NotSupportedException(ex.Message, ex), panel as Object);
				return;
			}
			iuipanelConEventos.onEvent.AddListener(unityAction);
		}

		// Token: 0x060003BD RID: 957 RVA: 0x0000DE9C File Offset: 0x0000C09C
		public static bool IsDefinedAttributeOnEnumValue<T>(Enum enumVal) where T : Attribute
		{
			Type type = enumVal.GetType();
			string name = Enum.GetName(type, enumVal);
			return Attribute.IsDefined(type.GetMember(name)[0], typeof(T), false);
		}

		// Token: 0x060003BE RID: 958 RVA: 0x0000DED0 File Offset: 0x0000C0D0
		public static T GetAttributeOfEnumValue<T>(Enum enumVal, out string enumName) where T : Attribute
		{
			Type type = enumVal.GetType();
			enumName = Enum.GetName(type, enumVal);
			return (T)((object)Attribute.GetCustomAttribute(type.GetMember(enumName)[0], typeof(T), false));
		}

		// Token: 0x060003BF RID: 959 RVA: 0x0000DF0C File Offset: 0x0000C10C
		public static T GetAttributeOfType<T>(Enum enumVal) where T : Attribute
		{
			string text;
			return DibujadorDynamico.GetAttributeOfEnumValue<T>(enumVal, out text);
		}

		// Token: 0x060003C0 RID: 960 RVA: 0x0000DF24 File Offset: 0x0000C124
		public static void SetUILabelAtributosToFont(IUIElemento elemento, TextMeshProUGUI labelText, IFontAttribute font, IBaseLayoutAttribute layoutParaText)
		{
			if (font != null)
			{
				if (font.fontSizeByUser)
				{
					labelText.fontSize = (float)font.fontSize;
				}
				if (font.fontStyleByUser)
				{
					labelText.fontStyle = font.fontStyle;
				}
				if (font.fontSizeModByUser)
				{
					labelText.fontSize = (float)((int)(labelText.fontSize * font.fontSizeMod));
				}
				if (font.alignmentByUser)
				{
					labelText.alignment = font.alignment;
				}
				if (font.colorByUser)
				{
					switch (font.color)
					{
					case ColorEnum.white:
						labelText.color = Color.white;
						break;
					case ColorEnum.black:
						labelText.color = Color.black;
						break;
					case ColorEnum.red:
						labelText.color = Color.red;
						break;
					case ColorEnum.gray:
						labelText.color = Color.gray;
						break;
					case ColorEnum.pink:
						labelText.color = Color.red * 0.5f + Color.white * 0.5f;
						break;
					default:
						throw new ArgumentOutOfRangeException(font.color.ToString());
					}
				}
			}
			if (layoutParaText != null && !(layoutParaText is IPanelLayoutAttribute))
			{
				if (((elemento != null) ? elemento.transform : null) != null && layoutParaText.scaleModByUser)
				{
					elemento.transform.localScale *= layoutParaText.scaleMod;
				}
				LayoutElement layoutElement = elemento.transform.GetComponent<LayoutElement>();
				if (layoutElement == null)
				{
					layoutElement = elemento.transform.gameObject.AddComponent<LayoutElement>();
				}
				if (layoutParaText.heightByUser)
				{
					layoutElement.preferredHeight = (layoutElement.minHeight = (float)layoutParaText.height);
				}
				if (layoutParaText.widthByUser)
				{
					layoutElement.preferredWidth = (layoutElement.minWidth = (float)layoutParaText.width);
				}
				if (layoutParaText.heightModByUser)
				{
					layoutElement.preferredHeight *= layoutParaText.heightMod;
					layoutElement.minHeight *= layoutParaText.heightMod;
				}
				if (layoutParaText.widthModByUser)
				{
					layoutElement.preferredWidth *= layoutParaText.widthMod;
					layoutElement.minWidth *= layoutParaText.widthMod;
				}
			}
			if (layoutParaText != null && !(layoutParaText is IPanelLayoutAttribute))
			{
				LayoutElement component = labelText.transform.GetComponent<LayoutElement>();
				if (component != null)
				{
					if (layoutParaText.heightByUser)
					{
						component.preferredHeight = (component.minHeight = (float)layoutParaText.height);
					}
					if (layoutParaText.widthByUser)
					{
						component.preferredWidth = (component.minWidth = (float)layoutParaText.width);
					}
					if (layoutParaText.heightModByUser)
					{
						component.preferredHeight *= layoutParaText.heightMod;
						component.minHeight *= layoutParaText.heightMod;
					}
					if (layoutParaText.widthModByUser)
					{
						component.preferredWidth *= layoutParaText.widthMod;
						component.minWidth *= layoutParaText.widthMod;
					}
				}
			}
			if (layoutParaText != null)
			{
				LayoutGroup component2 = elemento.transform.GetComponent<LayoutGroup>();
				if (component2 != null)
				{
					if (layoutParaText.leftPaddingByUser)
					{
						component2.padding.left = layoutParaText.leftPadding;
					}
					if (layoutParaText.rightPaddingByUser)
					{
						component2.padding.right = layoutParaText.rightPadding;
					}
					if (layoutParaText.topPaddingByUser)
					{
						component2.padding.top = layoutParaText.topPadding;
					}
					if (layoutParaText.bottomPaddingByUser)
					{
						component2.padding.bottom = layoutParaText.bottomPadding;
					}
				}
			}
		}

		// Token: 0x060003C1 RID: 961 RVA: 0x0000E298 File Offset: 0x0000C498
		public static void SetUILabelAtributosToElement(IUIElemento elemento, IBaseLayoutAttribute layoutParaElemento)
		{
			if (layoutParaElemento != null && !(layoutParaElemento is IPanelLayoutAttribute))
			{
				if (((elemento != null) ? elemento.transform : null) != null && layoutParaElemento.scaleModByUser)
				{
					elemento.transform.localScale *= layoutParaElemento.scaleMod;
				}
				LayoutElement layoutElement = elemento.transform.GetComponent<LayoutElement>();
				if (layoutElement == null)
				{
					layoutElement = elemento.transform.gameObject.AddComponent<LayoutElement>();
				}
				if (layoutParaElemento.heightByUser)
				{
					layoutElement.preferredHeight = (layoutElement.minHeight = (float)layoutParaElemento.height);
					layoutElement.flexibleHeight = 0f;
				}
				if (layoutParaElemento.widthByUser)
				{
					layoutElement.preferredWidth = (layoutElement.minWidth = (float)layoutParaElemento.width);
					layoutElement.flexibleWidth = 0f;
				}
				if (layoutParaElemento.heightModByUser)
				{
					layoutElement.preferredHeight *= layoutParaElemento.heightMod;
					layoutElement.minHeight *= layoutParaElemento.heightMod;
					layoutElement.flexibleHeight = 0f;
				}
				if (layoutParaElemento.widthModByUser)
				{
					layoutElement.preferredWidth *= layoutParaElemento.widthMod;
					layoutElement.minWidth *= layoutParaElemento.widthMod;
					layoutElement.flexibleWidth = 0f;
				}
			}
			if (layoutParaElemento != null)
			{
				LayoutGroup component = elemento.transform.GetComponent<LayoutGroup>();
				if (component != null)
				{
					if (layoutParaElemento.leftPaddingByUser)
					{
						component.padding.left = layoutParaElemento.leftPadding;
					}
					if (layoutParaElemento.rightPaddingByUser)
					{
						component.padding.right = layoutParaElemento.rightPadding;
					}
					if (layoutParaElemento.topPaddingByUser)
					{
						component.padding.top = layoutParaElemento.topPadding;
					}
					if (layoutParaElemento.bottomPaddingByUser)
					{
						component.padding.bottom = layoutParaElemento.bottomPadding;
					}
				}
			}
		}

		// Token: 0x060003C2 RID: 962 RVA: 0x0000E454 File Offset: 0x0000C654
		[Obsolete("", true)]
		public static void SetUILabelAtributos(IUIElemento elemento, TextMeshProUGUI labelText, IFontAttribute font, IBaseLayoutAttribute layoutParaElemento, IBaseLayoutAttribute layoutParaText)
		{
			if (font != null)
			{
				if (font.fontSizeByUser)
				{
					labelText.fontSize = (float)font.fontSize;
				}
				if (font.fontStyleByUser)
				{
					labelText.fontStyle = font.fontStyle;
				}
				if (font.fontSizeModByUser)
				{
					labelText.fontSize = (float)((int)(labelText.fontSize * font.fontSizeMod));
				}
				if (font.alignmentByUser)
				{
					labelText.alignment = font.alignment;
				}
				if (font.colorByUser)
				{
					switch (font.color)
					{
					case ColorEnum.white:
						labelText.color = Color.white;
						break;
					case ColorEnum.black:
						labelText.color = Color.black;
						break;
					case ColorEnum.red:
						labelText.color = Color.red;
						break;
					case ColorEnum.gray:
						labelText.color = Color.gray;
						break;
					case ColorEnum.pink:
						labelText.color = Color.red * 0.5f + Color.white * 0.5f;
						break;
					default:
						throw new ArgumentOutOfRangeException(font.color.ToString());
					}
				}
			}
			if (layoutParaElemento == null)
			{
				layoutParaElemento = layoutParaText;
			}
			if (layoutParaElemento != null && !(layoutParaElemento is IPanelLayoutAttribute))
			{
				if (((elemento != null) ? elemento.transform : null) != null && layoutParaElemento.scaleModByUser)
				{
					elemento.transform.localScale *= layoutParaElemento.scaleMod;
				}
				LayoutElement layoutElement = elemento.transform.GetComponent<LayoutElement>();
				if (layoutElement == null)
				{
					layoutElement = elemento.transform.gameObject.AddComponent<LayoutElement>();
				}
				if (layoutParaElemento.heightByUser)
				{
					layoutElement.preferredHeight = (layoutElement.minHeight = (float)layoutParaElemento.height);
				}
				if (layoutParaElemento.widthByUser)
				{
					layoutElement.preferredWidth = (layoutElement.minWidth = (float)layoutParaElemento.width);
				}
				if (layoutParaElemento.heightModByUser)
				{
					layoutElement.preferredHeight *= layoutParaElemento.heightMod;
					layoutElement.minHeight *= layoutParaElemento.heightMod;
				}
				if (layoutParaElemento.widthModByUser)
				{
					layoutElement.preferredWidth *= layoutParaElemento.widthMod;
					layoutElement.minWidth *= layoutParaElemento.widthMod;
				}
			}
			if (layoutParaText != null && !(layoutParaText is IPanelLayoutAttribute))
			{
				LayoutElement component = labelText.transform.GetComponent<LayoutElement>();
				if (component != null)
				{
					if (layoutParaText.heightByUser)
					{
						component.preferredHeight = (component.minHeight = (float)layoutParaText.height);
					}
					if (layoutParaText.widthByUser)
					{
						component.preferredWidth = (component.minWidth = (float)layoutParaText.width);
					}
					if (layoutParaText.heightModByUser)
					{
						component.preferredHeight *= layoutParaText.heightMod;
						component.minHeight *= layoutParaText.heightMod;
					}
					if (layoutParaText.widthModByUser)
					{
						component.preferredWidth *= layoutParaText.widthMod;
						component.minWidth *= layoutParaText.widthMod;
					}
				}
			}
			if (layoutParaElemento != null)
			{
				LayoutGroup component2 = elemento.transform.GetComponent<LayoutGroup>();
				if (component2 != null)
				{
					if (layoutParaElemento.leftPaddingByUser)
					{
						component2.padding.left = layoutParaElemento.leftPadding;
					}
					if (layoutParaElemento.rightPaddingByUser)
					{
						component2.padding.right = layoutParaElemento.rightPadding;
					}
					if (layoutParaElemento.topPaddingByUser)
					{
						component2.padding.top = layoutParaElemento.topPadding;
					}
					if (layoutParaElemento.bottomPaddingByUser)
					{
						component2.padding.bottom = layoutParaElemento.bottomPadding;
					}
				}
			}
		}

		// Token: 0x060003C3 RID: 963 RVA: 0x0000E7CF File Offset: 0x0000C9CF
		public static void SetUIText(TextMeshProUGUI labelText, TextoLocalizadoAttribute atributo)
		{
			labelText.text = atributo.text;
		}

		// Token: 0x060003C4 RID: 964 RVA: 0x0000E7E0 File Offset: 0x0000C9E0
		private IUIElemento dibujarAnalogueCal(IUIPanel panel, MemberInfo fieldInfo, object modelOwner, int index, IEnumerable<Attribute> attr, DibujadorDynamico.ExtraData extradata)
		{
			AnalogeCalibratorAttribute analogeCalibratorAttribute = attr.FirstOrDefault((Attribute a) => a is AnalogeCalibratorAttribute) as AnalogeCalibratorAttribute;
			if (analogeCalibratorAttribute == null)
			{
				return null;
			}
			RangeAttribute rangeAttribute = attr.FirstOrDefault((Attribute a) => a is RangeAttribute) as RangeAttribute;
			if (rangeAttribute == null)
			{
				rangeAttribute = new RangeAttribute(0f, 1f);
			}
			AnalogueCalibrationElement analogueCalibrationElement = (AnalogueCalibrationElement)Object.Instantiate<UIElemento>(MapaSingleton<MapaSingletonDeUIPrefabs>.instance.analogueCalibration);
			analogueCalibrationElement.valueDrawerPositive.decimales = (analogueCalibrationElement.valueDrawerNegative.decimales = analogeCalibratorAttribute.decimalesDibujar);
			analogueCalibrationElement.sliderPositive.minValue = (analogueCalibrationElement.sliderNegative.minValue = rangeAttribute.min);
			analogueCalibrationElement.sliderPositive.maxValue = (analogueCalibrationElement.sliderNegative.maxValue = rangeAttribute.max);
			this.PostDibujarElemento1(panel, analogueCalibrationElement, fieldInfo, attr, modelOwner, index, true, extradata);
			this.PostDibujarElemento2(panel, analogueCalibrationElement, fieldInfo, attr, modelOwner, extradata);
			return analogueCalibrationElement;
		}

		// Token: 0x060003C5 RID: 965 RVA: 0x0000E8F4 File Offset: 0x0000CAF4
		private IUIElemento dibujarDeslizableHelpButt(IUIPanel panel, MemberInfo fieldInfo, object modelOwner, int index, IEnumerable<Attribute> attr, DibujadorDynamico.ExtraData extradata)
		{
			DeslizableHelpBotonAttribute deslizableHelpBotonAttribute = attr.FirstOrDefault((Attribute a) => a is DeslizableHelpBotonAttribute) as DeslizableHelpBotonAttribute;
			if (deslizableHelpBotonAttribute == null)
			{
				return null;
			}
			RangeAttribute rangeAttribute = attr.FirstOrDefault((Attribute a) => a is RangeAttribute) as RangeAttribute;
			if (rangeAttribute == null)
			{
				rangeAttribute = new RangeAttribute(0f, 100f);
			}
			DeslizableElementHelpButton deslizableElementHelpButton = Object.Instantiate<DeslizableElementHelpButton>(MapaSingleton<MapaSingletonDeUIPrefabs>.instance.deslizableHelpBoton);
			deslizableElementHelpButton.valueDrawer.decimales = deslizableHelpBotonAttribute.decimalesDibujar;
			deslizableElementHelpButton.slider.minValue = rangeAttribute.min;
			deslizableElementHelpButton.slider.maxValue = rangeAttribute.max;
			deslizableElementHelpButton.slider.wholeNumbers = deslizableHelpBotonAttribute.wholeNumbers;
			MethodInfo methodInfo;
			if (extradata.paraType.secondaryActions.TryGetValue(new ValueTuple<Type, string>(modelOwner.GetType(), fieldInfo.Name), out methodInfo))
			{
				DibujadorDynamico.SetDelegadoAClickable(deslizableElementHelpButton, methodInfo, panel, modelOwner);
			}
			this.PostDibujarElemento1(panel, deslizableElementHelpButton, fieldInfo, attr, modelOwner, index, false, extradata);
			this.PostDibujarElemento2(panel, deslizableElementHelpButton, fieldInfo, attr, modelOwner, extradata);
			return deslizableElementHelpButton;
		}

		// Token: 0x060003C6 RID: 966 RVA: 0x0000EA14 File Offset: 0x0000CC14
		private IUIElemento dibujarDeslizable(IUIPanel panel, MemberInfo fieldInfo, object modelOwner, int index, IEnumerable<Attribute> attr, DibujadorDynamico.ExtraData extradata)
		{
			DeslizableAttribute deslizableAttribute = attr.FirstOrDefault((Attribute a) => a is DeslizableAttribute) as DeslizableAttribute;
			if (deslizableAttribute == null)
			{
				return null;
			}
			RangeAttribute rangeAttribute = attr.FirstOrDefault((Attribute a) => a is RangeAttribute) as RangeAttribute;
			if (rangeAttribute == null)
			{
				rangeAttribute = new RangeAttribute(0f, 100f);
			}
			DeslizableElement deslizableElement = Object.Instantiate<DeslizableElement>(MapaSingleton<MapaSingletonDeUIPrefabs>.instance.deslizable);
			deslizableElement.valueDrawer.decimales = deslizableAttribute.decimalesDibujar;
			deslizableElement.slider.minValue = rangeAttribute.min;
			deslizableElement.slider.maxValue = rangeAttribute.max;
			deslizableElement.slider.wholeNumbers = deslizableAttribute.wholeNumbers;
			this.PostDibujarElemento1(panel, deslizableElement, fieldInfo, attr, modelOwner, index, false, extradata);
			this.PostDibujarElemento2(panel, deslizableElement, fieldInfo, attr, modelOwner, extradata);
			return deslizableElement;
		}

		// Token: 0x060003C7 RID: 967 RVA: 0x0000EB08 File Offset: 0x0000CD08
		private IUIElemento dibujarDeslizableConToolTip(IUIPanel panel, MemberInfo fieldInfo, object modelOwner, int index, IEnumerable<Attribute> attr, DibujadorDynamico.ExtraData extradata)
		{
			DeslizableConToolTipAttribute deslizableConToolTipAttribute = attr.FirstOrDefault((Attribute a) => a is DeslizableConToolTipAttribute) as DeslizableConToolTipAttribute;
			if (deslizableConToolTipAttribute == null)
			{
				return null;
			}
			RangeAttribute rangeAttribute = attr.FirstOrDefault((Attribute a) => a is RangeAttribute) as RangeAttribute;
			if (rangeAttribute == null)
			{
				rangeAttribute = new RangeAttribute(0f, 100f);
			}
			DeslizableElementToolTip deslizableElementToolTip = Object.Instantiate<DeslizableElementToolTip>(MapaSingleton<MapaSingletonDeUIPrefabs>.instance.deslizableConToolTip);
			deslizableElementToolTip.valueDrawer.decimales = deslizableConToolTipAttribute.decimalesDibujar;
			deslizableElementToolTip.slider.minValue = rangeAttribute.min;
			deslizableElementToolTip.slider.maxValue = rangeAttribute.max;
			deslizableElementToolTip.slider.wholeNumbers = deslizableConToolTipAttribute.wholeNumbers;
			this.PostDibujarElemento1(panel, deslizableElementToolTip, fieldInfo, attr, modelOwner, index, false, extradata);
			this.PostDibujarElemento2(panel, deslizableElementToolTip, fieldInfo, attr, modelOwner, extradata);
			return deslizableElementToolTip;
		}

		// Token: 0x060003C8 RID: 968 RVA: 0x0000EBFC File Offset: 0x0000CDFC
		private IUIElemento dibujarInputToolTip(IUIPanel panel, MemberInfo fieldInfo, object modelOwner, int index, IEnumerable<Attribute> attr, DibujadorDynamico.ExtraData extradata)
		{
			InputConToolTipAttribute inputConToolTipAttribute = attr.FirstOrDefault((Attribute a) => a is InputConToolTipAttribute) as InputConToolTipAttribute;
			if (inputConToolTipAttribute == null)
			{
				return null;
			}
			InputElementToolTip inputElementToolTip = Object.Instantiate<InputElementToolTip>(MapaSingleton<MapaSingletonDeUIPrefabs>.instance.inputToolTip);
			inputElementToolTip.inputField.contentType = (TMP_InputField.ContentType)inputConToolTipAttribute.contentType;
			this.PostDibujarElemento1(panel, inputElementToolTip, fieldInfo, attr, modelOwner, index, false, extradata);
			this.PostDibujarElemento2(panel, inputElementToolTip, fieldInfo, attr, modelOwner, extradata);
			return inputElementToolTip;
		}

		// Token: 0x060003C9 RID: 969 RVA: 0x0000EC7C File Offset: 0x0000CE7C
		private IUIElemento dibujarDeslizableLabelCorto(IUIPanel panel, MemberInfo fieldInfo, object modelOwner, int index, IEnumerable<Attribute> attr, DibujadorDynamico.ExtraData extradata)
		{
			DeslizableLabelCortoAttribute deslizableLabelCortoAttribute = attr.FirstOrDefault((Attribute a) => a is DeslizableLabelCortoAttribute) as DeslizableLabelCortoAttribute;
			if (deslizableLabelCortoAttribute == null)
			{
				return null;
			}
			RangeAttribute rangeAttribute = attr.FirstOrDefault((Attribute a) => a is RangeAttribute) as RangeAttribute;
			if (rangeAttribute == null)
			{
				rangeAttribute = new RangeAttribute(0f, 100f);
			}
			DeslizableElementToolTip deslizableElementToolTip = Object.Instantiate<DeslizableElementToolTip>(MapaSingleton<MapaSingletonDeUIPrefabs>.instance.deslizableLabelCorto);
			deslizableElementToolTip.valueDrawer.decimales = deslizableLabelCortoAttribute.decimalesDibujar;
			deslizableElementToolTip.slider.minValue = rangeAttribute.min;
			deslizableElementToolTip.slider.maxValue = rangeAttribute.max;
			deslizableElementToolTip.slider.wholeNumbers = deslizableLabelCortoAttribute.wholeNumbers;
			this.PostDibujarElemento1(panel, deslizableElementToolTip, fieldInfo, attr, modelOwner, index, false, extradata);
			this.PostDibujarElemento2(panel, deslizableElementToolTip, fieldInfo, attr, modelOwner, extradata);
			return deslizableElementToolTip;
		}

		// Token: 0x060003CA RID: 970 RVA: 0x0000ED70 File Offset: 0x0000CF70
		private IUIElemento dibujarElement<T_Attribute>(IUIPanel panel, Func<UIElemento> prefabGetter, MemberInfo fieldInfo, object modelOwner, int index, IEnumerable<Attribute> attr, DibujadorDynamico.ExtraData extradata) where T_Attribute : DynamicUIElementAttribute
		{
			if (!(attr.FirstOrDefault((Attribute a) => a is T_Attribute) is T_Attribute))
			{
				return null;
			}
			UIElemento uielemento = Object.Instantiate<UIElemento>(prefabGetter());
			if (uielemento is IUIBoton)
			{
				DibujadorDynamico.SetDelegadoAClickable(uielemento as IUIBoton, fieldInfo as MethodInfo, panel, modelOwner);
			}
			this.PostDibujarElemento1(panel, uielemento, fieldInfo, attr, modelOwner, index, false, extradata);
			this.PostDibujarElemento2(panel, uielemento, fieldInfo, attr, modelOwner, extradata);
			return uielemento;
		}

		// Token: 0x060003CB RID: 971 RVA: 0x0000EE00 File Offset: 0x0000D000
		private IUIElemento dibujarElementAny(IUIPanel panel, Func<UIElemento> prefabGetter, MemberInfo fieldInfo, object modelOwner, int index, IEnumerable<Attribute> attr, DibujadorDynamico.ExtraData extradata)
		{
			UIElemento uielemento = Object.Instantiate<UIElemento>(prefabGetter());
			if (uielemento is IUIBoton)
			{
				DibujadorDynamico.SetDelegadoAClickable(uielemento as IUIBoton, fieldInfo as MethodInfo, panel, modelOwner);
			}
			this.PostDibujarElemento1(panel, uielemento, fieldInfo, attr, modelOwner, index, false, extradata);
			this.PostDibujarElemento2(panel, uielemento, fieldInfo, attr, modelOwner, extradata);
			return uielemento;
		}

		// Token: 0x060003CC RID: 972 RVA: 0x0000EE58 File Offset: 0x0000D058
		private IUIElemento dibujarClickableDescriptableLabel(IUIPanel panel, MemberInfo fieldInfo, object modelOwner, int index, IEnumerable<Attribute> attr, DibujadorDynamico.ExtraData extradata)
		{
			if (!(attr.FirstOrDefault((Attribute a) => a is ClickableLabelDescriptableAttribute) is ClickableLabelDescriptableAttribute))
			{
				return null;
			}
			BotonElementBase botonElementBase = Object.Instantiate<BotonElementBase>(MapaSingleton<MapaSingletonDeUIPrefabs>.instance.clickableLabelDescriptable);
			DibujadorDynamico.SetDelegadoAClickable(botonElementBase, fieldInfo as MethodInfo, panel, modelOwner);
			this.PostDibujarElemento1(panel, botonElementBase, fieldInfo, attr, modelOwner, index, false, extradata);
			this.PostDibujarElemento2(panel, botonElementBase, fieldInfo, attr, modelOwner, extradata);
			return botonElementBase;
		}

		// Token: 0x060003CD RID: 973 RVA: 0x0000EED4 File Offset: 0x0000D0D4
		private IUIElemento dibujarClickableDescriptableLabelModding(IUIPanel panel, MemberInfo fieldInfo, object modelOwner, int index, IEnumerable<Attribute> attr, DibujadorDynamico.ExtraData extradata)
		{
			BotonElementBase botonElementBase = Object.Instantiate<BotonElementBase>(MapaSingleton<MapaSingletonDeUIPrefabs>.instance.clickableLabelDescriptable);
			DibujadorDynamico.SetDelegadoAClickable(botonElementBase, fieldInfo as MethodInfo, panel, modelOwner);
			this.PostDibujarElemento1(panel, botonElementBase, fieldInfo, attr, modelOwner, index, false, extradata);
			this.PostDibujarElemento2(panel, botonElementBase, fieldInfo, attr, modelOwner, extradata);
			return botonElementBase;
		}

		// Token: 0x060003CE RID: 974 RVA: 0x0000EF20 File Offset: 0x0000D120
		private IUIElemento dibujarClickableDescriptableLabelCompacto(IUIPanel panel, MemberInfo fieldInfo, object modelOwner, int index, IEnumerable<Attribute> attr, DibujadorDynamico.ExtraData extradata)
		{
			if (!(attr.FirstOrDefault((Attribute a) => a is ClickableLabelDescriptableCompactoAttribute) is ClickableLabelDescriptableCompactoAttribute))
			{
				return null;
			}
			BotonElementBase botonElementBase = Object.Instantiate<BotonElementBase>(MapaSingleton<MapaSingletonDeUIPrefabs>.instance.clickableLabelDescriptableCompacto);
			DibujadorDynamico.SetDelegadoAClickable(botonElementBase, fieldInfo as MethodInfo, panel, modelOwner);
			this.PostDibujarElemento1(panel, botonElementBase, fieldInfo, attr, modelOwner, index, false, extradata);
			this.PostDibujarElemento2(panel, botonElementBase, fieldInfo, attr, modelOwner, extradata);
			return botonElementBase;
		}

		// Token: 0x060003CF RID: 975 RVA: 0x0000EF9C File Offset: 0x0000D19C
		private IUIElemento dibujarSelectablePortrait(IUIPanel panel, MemberInfo fieldInfo, object modelOwner, int index, IEnumerable<Attribute> attr, DibujadorDynamico.ExtraData extradata)
		{
			if (!(attr.FirstOrDefault((Attribute a) => a is PortraitAttribute) is PortraitAttribute))
			{
				return null;
			}
			SelectablePortrait selectablePortrait = Object.Instantiate<SelectablePortrait>(MapaSingleton<MapaSingletonDeUIPrefabs>.instance.selectablePortrait);
			this.PostDibujarElemento1(panel, selectablePortrait, fieldInfo, attr, modelOwner, index, false, extradata);
			this.PostDibujarElemento2(panel, selectablePortrait, fieldInfo, attr, modelOwner, extradata);
			return selectablePortrait;
		}

		// Token: 0x060003D0 RID: 976 RVA: 0x0000F008 File Offset: 0x0000D208
		private IUIElemento dibujarSelectableFavoritableGenericPortrait(IUIPanel panel, MemberInfo fieldInfo, object modelOwner, int index, IEnumerable<Attribute> attr, DibujadorDynamico.ExtraData extradata)
		{
			FavoritableGenericPortraitAttribute favoritableGenericPortraitAttribute = attr.FirstOrDefault((Attribute a) => a is FavoritableGenericPortraitAttribute) as FavoritableGenericPortraitAttribute;
			if (favoritableGenericPortraitAttribute == null)
			{
				return null;
			}
			SelectableFavoritableGenericPortrait selectableFavoritableGenericPortrait = Object.Instantiate<SelectableFavoritableGenericPortrait>(MapaSingleton<MapaSingletonDeUIPrefabs>.instance.selectableFavoritableGenericPortrait);
			selectableFavoritableGenericPortrait.imageIsDiskAsset = favoritableGenericPortraitAttribute.imageIsDiskAsset;
			this.PostDibujarElemento1(panel, selectableFavoritableGenericPortrait, fieldInfo, attr, modelOwner, index, false, extradata);
			this.PostDibujarElemento2(panel, selectableFavoritableGenericPortrait, fieldInfo, attr, modelOwner, extradata);
			return selectableFavoritableGenericPortrait;
		}

		// Token: 0x060003D1 RID: 977 RVA: 0x0000F084 File Offset: 0x0000D284
		private IUIElemento dibujarSelectableWorkingModelPortrait(IUIPanel panel, MemberInfo fieldInfo, object modelOwner, int index, IEnumerable<Attribute> attr, DibujadorDynamico.ExtraData extradata)
		{
			if (!(attr.FirstOrDefault((Attribute a) => a is WorkingModelPortraitAttribute) is WorkingModelPortraitAttribute))
			{
				return null;
			}
			SelectableWorkingModelPortrait selectableWorkingModelPortrait = Object.Instantiate<SelectableWorkingModelPortrait>(MapaSingleton<MapaSingletonDeUIPrefabs>.instance.selectableWorkingModelPortrait);
			this.PostDibujarElemento1(panel, selectableWorkingModelPortrait, fieldInfo, attr, modelOwner, index, false, extradata);
			this.PostDibujarElemento2(panel, selectableWorkingModelPortrait, fieldInfo, attr, modelOwner, extradata);
			return selectableWorkingModelPortrait;
		}

		// Token: 0x060003D2 RID: 978 RVA: 0x0000F0F0 File Offset: 0x0000D2F0
		private IUIElemento dibujarSelectableOutfitPortrait(IUIPanel panel, MemberInfo fieldInfo, object modelOwner, int index, IEnumerable<Attribute> attr, DibujadorDynamico.ExtraData extradata)
		{
			if (!(attr.FirstOrDefault((Attribute a) => a is OutfitPortraitAttribute) is OutfitPortraitAttribute))
			{
				return null;
			}
			SelectableOutfitPortrait selectableOutfitPortrait = Object.Instantiate<SelectableOutfitPortrait>(MapaSingleton<MapaSingletonDeUIPrefabs>.instance.selectableOutfitPortrait);
			this.PostDibujarElemento1(panel, selectableOutfitPortrait, fieldInfo, attr, modelOwner, index, false, extradata);
			this.PostDibujarElemento2(panel, selectableOutfitPortrait, fieldInfo, attr, modelOwner, extradata);
			return selectableOutfitPortrait;
		}

		// Token: 0x060003D3 RID: 979 RVA: 0x0000F15C File Offset: 0x0000D35C
		private IUIElemento dibujarSelectableGesturePortrait(IUIPanel panel, MemberInfo fieldInfo, object modelOwner, int index, IEnumerable<Attribute> attr, DibujadorDynamico.ExtraData extradata)
		{
			if (!(attr.FirstOrDefault((Attribute a) => a is GesturePortraitAttribute) is GesturePortraitAttribute))
			{
				return null;
			}
			SelectableGesturePortrait selectableGesturePortrait = Object.Instantiate<SelectableGesturePortrait>(MapaSingleton<MapaSingletonDeUIPrefabs>.instance.selectableGesturePortrait);
			this.PostDibujarElemento1(panel, selectableGesturePortrait, fieldInfo, attr, modelOwner, index, false, extradata);
			this.PostDibujarElemento2(panel, selectableGesturePortrait, fieldInfo, attr, modelOwner, extradata);
			return selectableGesturePortrait;
		}

		// Token: 0x060003D4 RID: 980 RVA: 0x0000F1C8 File Offset: 0x0000D3C8
		private IUIElemento dibujarSelectableMakeoverPortrait(IUIPanel panel, MemberInfo fieldInfo, object modelOwner, int index, IEnumerable<Attribute> attr, DibujadorDynamico.ExtraData extradata)
		{
			if (!(attr.FirstOrDefault((Attribute a) => a is MakeoverPortraitAttribute) is MakeoverPortraitAttribute))
			{
				return null;
			}
			SelectableMakeoverPortrait selectableMakeoverPortrait = Object.Instantiate<SelectableMakeoverPortrait>(MapaSingleton<MapaSingletonDeUIPrefabs>.instance.selectableMakeoverPortrait);
			this.PostDibujarElemento1(panel, selectableMakeoverPortrait, fieldInfo, attr, modelOwner, index, false, extradata);
			this.PostDibujarElemento2(panel, selectableMakeoverPortrait, fieldInfo, attr, modelOwner, extradata);
			return selectableMakeoverPortrait;
		}

		// Token: 0x060003D5 RID: 981 RVA: 0x0000F234 File Offset: 0x0000D434
		private IUIElemento dibujarSelectablePosePortrait(IUIPanel panel, MemberInfo fieldInfo, object modelOwner, int index, IEnumerable<Attribute> attr, DibujadorDynamico.ExtraData extradata)
		{
			if (!(attr.FirstOrDefault((Attribute a) => a is PosePortraitAttribute) is PosePortraitAttribute))
			{
				return null;
			}
			SelectablePosePortrait selectablePosePortrait = Object.Instantiate<SelectablePosePortrait>(MapaSingleton<MapaSingletonDeUIPrefabs>.instance.selectablePosePortrait);
			this.PostDibujarElemento1(panel, selectablePosePortrait, fieldInfo, attr, modelOwner, index, false, extradata);
			this.PostDibujarElemento2(panel, selectablePosePortrait, fieldInfo, attr, modelOwner, extradata);
			return selectablePosePortrait;
		}

		// Token: 0x060003D6 RID: 982 RVA: 0x0000F2A0 File Offset: 0x0000D4A0
		private IUIElemento dibujarSelectableOfficePortrait(IUIPanel panel, MemberInfo fieldInfo, object modelOwner, int index, IEnumerable<Attribute> attr, DibujadorDynamico.ExtraData extradata)
		{
			OfficePortraitAttribute officePortraitAttribute = attr.FirstOrDefault((Attribute a) => a is OfficePortraitAttribute) as OfficePortraitAttribute;
			if (officePortraitAttribute == null)
			{
				return null;
			}
			SelectableOfficePortrait selectableOfficePortrait = Object.Instantiate<SelectableOfficePortrait>(MapaSingleton<MapaSingletonDeUIPrefabs>.instance.selectableOfficePortrait);
			selectableOfficePortrait.imageIsDiskAsset = officePortraitAttribute.imageIsDiskAsset;
			this.PostDibujarElemento1(panel, selectableOfficePortrait, fieldInfo, attr, modelOwner, index, false, extradata);
			this.PostDibujarElemento2(panel, selectableOfficePortrait, fieldInfo, attr, modelOwner, extradata);
			return selectableOfficePortrait;
		}

		// Token: 0x060003D7 RID: 983 RVA: 0x0000F31C File Offset: 0x0000D51C
		private IUIElemento dibujarSelectableJobPortrait(IUIPanel panel, MemberInfo fieldInfo, object modelOwner, int index, IEnumerable<Attribute> attr, DibujadorDynamico.ExtraData extradata)
		{
			JobPortraitAttribute jobPortraitAttribute = attr.FirstOrDefault((Attribute a) => a is JobPortraitAttribute) as JobPortraitAttribute;
			if (jobPortraitAttribute == null)
			{
				return null;
			}
			SelectableJobPortrait selectableJobPortrait = Object.Instantiate<SelectableJobPortrait>(MapaSingleton<MapaSingletonDeUIPrefabs>.instance.selectableJobPortrait);
			selectableJobPortrait.imageIsDiskAsset = jobPortraitAttribute.imageIsDiskAsset;
			this.PostDibujarElemento1(panel, selectableJobPortrait, fieldInfo, attr, modelOwner, index, false, extradata);
			this.PostDibujarElemento2(panel, selectableJobPortrait, fieldInfo, attr, modelOwner, extradata);
			return selectableJobPortrait;
		}

		// Token: 0x060003D8 RID: 984 RVA: 0x0000F398 File Offset: 0x0000D598
		private IUIElemento dibujarSelectableProfilePortrait(IUIPanel panel, MemberInfo fieldInfo, object modelOwner, int index, IEnumerable<Attribute> attr, DibujadorDynamico.ExtraData extradata)
		{
			if (!(attr.FirstOrDefault((Attribute a) => a is InterpretationProfilePortraitAttribute) is InterpretationProfilePortraitAttribute))
			{
				return null;
			}
			SelectableProfilePortrait selectableProfilePortrait = Object.Instantiate<SelectableProfilePortrait>(MapaSingleton<MapaSingletonDeUIPrefabs>.instance.selectableProfilePortrait);
			this.PostDibujarElemento1(panel, selectableProfilePortrait, fieldInfo, attr, modelOwner, index, false, extradata);
			this.PostDibujarElemento2(panel, selectableProfilePortrait, fieldInfo, attr, modelOwner, extradata);
			return selectableProfilePortrait;
		}

		// Token: 0x060003D9 RID: 985 RVA: 0x0000F404 File Offset: 0x0000D604
		private IUIElemento dibujarGameplayObjective(IUIPanel panel, MemberInfo fieldInfo, object modelOwner, int index, IEnumerable<Attribute> attr, DibujadorDynamico.ExtraData extradata)
		{
			if (!(attr.FirstOrDefault((Attribute a) => a is GameplayObjectiveAttribute) is GameplayObjectiveAttribute))
			{
				return null;
			}
			GamePlayObjectiveUIElemento gamePlayObjectiveUIElemento = Object.Instantiate<GamePlayObjectiveUIElemento>(MapaSingleton<MapaSingletonDeUIPrefabs>.instance.gameplayObjective);
			this.PostDibujarElemento1(panel, gamePlayObjectiveUIElemento, fieldInfo, attr, modelOwner, index, false, extradata);
			this.PostDibujarElemento2(panel, gamePlayObjectiveUIElemento, fieldInfo, attr, modelOwner, extradata);
			return gamePlayObjectiveUIElemento;
		}

		// Token: 0x060003DA RID: 986 RVA: 0x0000F470 File Offset: 0x0000D670
		private IUIElemento dibujarClickableLabelConValor(IUIPanel panel, MemberInfo fieldInfo, object modelOwner, int index, IEnumerable<Attribute> attr, DibujadorDynamico.ExtraData extradata)
		{
			if (!(attr.FirstOrDefault((Attribute a) => a is ClickableLabelConValorAttribute) is ClickableLabelConValorAttribute))
			{
				return null;
			}
			BotonElementBase botonElementBase = Object.Instantiate<BotonElementBase>(MapaSingleton<MapaSingletonDeUIPrefabs>.instance.clickableLabelConValor);
			DibujadorDynamico.SetDelegadoAClickable(botonElementBase, fieldInfo as MethodInfo, panel, modelOwner);
			this.PostDibujarElemento1(panel, botonElementBase, fieldInfo, attr, modelOwner, index, false, extradata);
			this.PostDibujarElemento2(panel, botonElementBase, fieldInfo, attr, modelOwner, extradata);
			return botonElementBase;
		}

		// Token: 0x060003DB RID: 987 RVA: 0x0000F4EC File Offset: 0x0000D6EC
		private IUIElemento dibujarClickableLabel(IUIPanel panel, MemberInfo fieldInfo, object modelOwner, int index, IEnumerable<Attribute> attr, DibujadorDynamico.ExtraData extradata)
		{
			if (!(attr.FirstOrDefault((Attribute a) => a is ClickableLabelAttribute) is ClickableLabelAttribute))
			{
				return null;
			}
			BotonElementBase botonElementBase = Object.Instantiate<BotonElementBase>(MapaSingleton<MapaSingletonDeUIPrefabs>.instance.clickableLabel);
			DibujadorDynamico.SetDelegadoAClickable(botonElementBase, fieldInfo as MethodInfo, panel, modelOwner);
			this.PostDibujarElemento1(panel, botonElementBase, fieldInfo, attr, modelOwner, index, false, extradata);
			this.PostDibujarElemento2(panel, botonElementBase, fieldInfo, attr, modelOwner, extradata);
			return botonElementBase;
		}

		// Token: 0x060003DC RID: 988 RVA: 0x0000F568 File Offset: 0x0000D768
		private IUIElemento dibujarClickableLabelFav(IUIPanel panel, MemberInfo fieldInfo, object modelOwner, int index, IEnumerable<Attribute> attr, DibujadorDynamico.ExtraData extradata)
		{
			if (!(attr.FirstOrDefault((Attribute a) => a is ClickableFavoritableLabelAttribute) is ClickableFavoritableLabelAttribute))
			{
				return null;
			}
			BotonElementBase botonElementBase = Object.Instantiate<BotonElementBase>(MapaSingleton<MapaSingletonDeUIPrefabs>.instance.clickableFavoritableLabel);
			DibujadorDynamico.SetDelegadoAClickable(botonElementBase, fieldInfo as MethodInfo, panel, modelOwner);
			this.PostDibujarElemento1(panel, botonElementBase, fieldInfo, attr, modelOwner, index, false, extradata);
			this.PostDibujarElemento2(panel, botonElementBase, fieldInfo, attr, modelOwner, extradata);
			return botonElementBase;
		}

		// Token: 0x060003DD RID: 989 RVA: 0x0000F5E4 File Offset: 0x0000D7E4
		private IUIElemento dibujarDesplegable(IUIPanel panel, MemberInfo fieldInfo, object modelOwner, int index, IEnumerable<Attribute> attr, DibujadorDynamico.ExtraData extradata)
		{
			if (!(attr.FirstOrDefault((Attribute a) => a is DesplegableAttribute) is DesplegableAttribute))
			{
				return null;
			}
			DesplegableElement desplegableElement = Object.Instantiate<DesplegableElement>(MapaSingleton<MapaSingletonDeUIPrefabs>.instance.desplegable);
			this.PostDibujarElemento1(panel, desplegableElement, fieldInfo, attr, modelOwner, index, false, extradata);
			this.PostDibujarElemento2(panel, desplegableElement, fieldInfo, attr, modelOwner, extradata);
			return desplegableElement;
		}

		// Token: 0x060003DE RID: 990 RVA: 0x0000F650 File Offset: 0x0000D850
		private IUIElemento dibujarDesplegableCompacto(IUIPanel panel, MemberInfo fieldInfo, object modelOwner, int index, IEnumerable<Attribute> attr, DibujadorDynamico.ExtraData extradata)
		{
			DesplegableElementToolTip desplegableElementToolTip = Object.Instantiate<DesplegableElementToolTip>(MapaSingleton<MapaSingletonDeUIPrefabs>.instance.desplegableCompacto);
			this.PostDibujarElemento1(panel, desplegableElementToolTip, fieldInfo, attr, modelOwner, index, false, extradata);
			this.PostDibujarElemento2(panel, desplegableElementToolTip, fieldInfo, attr, modelOwner, extradata);
			return desplegableElementToolTip;
		}

		// Token: 0x060003DF RID: 991 RVA: 0x0000F690 File Offset: 0x0000D890
		private IUIElemento dibujarDesplegableConToolTip(IUIPanel panel, MemberInfo fieldInfo, object modelOwner, int index, IEnumerable<Attribute> attr, DibujadorDynamico.ExtraData extradata)
		{
			DesplegableElementToolTip desplegableElementToolTip = Object.Instantiate<DesplegableElementToolTip>(MapaSingleton<MapaSingletonDeUIPrefabs>.instance.desplegableConToolTip);
			this.PostDibujarElemento1(panel, desplegableElementToolTip, fieldInfo, attr, modelOwner, index, false, extradata);
			this.PostDibujarElemento2(panel, desplegableElementToolTip, fieldInfo, attr, modelOwner, extradata);
			return desplegableElementToolTip;
		}

		// Token: 0x060003E0 RID: 992 RVA: 0x0000F6D0 File Offset: 0x0000D8D0
		private IUIElemento dibujarDesplegableLabelCorto(IUIPanel panel, MemberInfo fieldInfo, object modelOwner, int index, IEnumerable<Attribute> attr, DibujadorDynamico.ExtraData extradata)
		{
			DesplegableElementToolTip desplegableElementToolTip = Object.Instantiate<DesplegableElementToolTip>(MapaSingleton<MapaSingletonDeUIPrefabs>.instance.desplegableLabelCorto);
			this.PostDibujarElemento1(panel, desplegableElementToolTip, fieldInfo, attr, modelOwner, index, false, extradata);
			this.PostDibujarElemento2(panel, desplegableElementToolTip, fieldInfo, attr, modelOwner, extradata);
			return desplegableElementToolTip;
		}

		// Token: 0x060003E1 RID: 993 RVA: 0x0000F710 File Offset: 0x0000D910
		private IUIElemento dibujarDesplegableHelp(IUIPanel panel, MemberInfo fieldInfo, object modelOwner, int index, IEnumerable<Attribute> attr, DibujadorDynamico.ExtraData extradata)
		{
			if (!(attr.FirstOrDefault((Attribute a) => a is DesplegableHelpBotonAttribute) is DesplegableHelpBotonAttribute))
			{
				return null;
			}
			DesplegableElementHelpButton desplegableElementHelpButton = Object.Instantiate<DesplegableElementHelpButton>(MapaSingleton<MapaSingletonDeUIPrefabs>.instance.desplegableHelpBoton);
			MethodInfo methodInfo;
			if (extradata.paraType.secondaryActions.TryGetValue(new ValueTuple<Type, string>(modelOwner.GetType(), fieldInfo.Name), out methodInfo))
			{
				DibujadorDynamico.SetDelegadoAClickable(desplegableElementHelpButton, methodInfo, panel, modelOwner);
			}
			this.PostDibujarElemento1(panel, desplegableElementHelpButton, fieldInfo, attr, modelOwner, index, false, extradata);
			this.PostDibujarElemento2(panel, desplegableElementHelpButton, fieldInfo, attr, modelOwner, extradata);
			return desplegableElementHelpButton;
		}

		// Token: 0x060003E2 RID: 994 RVA: 0x0000F7AC File Offset: 0x0000D9AC
		private IUIElemento dibujaToggle(IUIPanel panel, MemberInfo fieldInfo, object modelOwner, int index, IEnumerable<Attribute> attibutos, DibujadorDynamico.ExtraData extradata)
		{
			if (!(attibutos.FirstOrDefault((Attribute a) => a is ToggleAttribute) is ToggleAttribute))
			{
				return null;
			}
			UIElemento uielemento = Object.Instantiate<UIElemento>(MapaSingleton<MapaSingletonDeUIPrefabs>.instance.toggle);
			this.PostDibujarElemento1(panel, uielemento, fieldInfo, attibutos, modelOwner, index, false, extradata);
			this.PostDibujarElemento2(panel, uielemento, fieldInfo, attibutos, modelOwner, extradata);
			return uielemento;
		}

		// Token: 0x060003E3 RID: 995 RVA: 0x0000F818 File Offset: 0x0000DA18
		private IUIElemento dibujaTitleLabel(IUIPanel panel, MemberInfo fieldInfo, object modelOwner, int index, IEnumerable<Attribute> attibutos, DibujadorDynamico.ExtraData extradata)
		{
			if (!(attibutos.FirstOrDefault((Attribute a) => a is TittleLabelAttribute) is TittleLabelAttribute))
			{
				return null;
			}
			UIElemento uielemento = Object.Instantiate<TituloElement>(MapaSingleton<MapaSingletonDeUIPrefabs>.instance.titulo);
			this.PostDibujarElemento1(panel, uielemento, fieldInfo, attibutos, modelOwner, index, false, extradata);
			this.PostDibujarElemento2(panel, uielemento, fieldInfo, attibutos, modelOwner, extradata);
			return uielemento;
		}

		// Token: 0x060003E4 RID: 996 RVA: 0x0000F884 File Offset: 0x0000DA84
		private IUIElemento dibujaLabelPar(IUIPanel panel, MemberInfo fieldInfo, object modelOwner, int index, IEnumerable<Attribute> attibutos, DibujadorDynamico.ExtraData extradata)
		{
			if (!(attibutos.FirstOrDefault((Attribute a) => a is LabelParAttribute) is LabelParAttribute))
			{
				return null;
			}
			UIElemento uielemento = Object.Instantiate<LabelParElement>(MapaSingleton<MapaSingletonDeUIPrefabs>.instance.labelPar);
			this.PostDibujarElemento1(panel, uielemento, fieldInfo, attibutos, modelOwner, index, false, extradata);
			this.PostDibujarElemento2(panel, uielemento, fieldInfo, attibutos, modelOwner, extradata);
			return uielemento;
		}

		// Token: 0x060003E5 RID: 997 RVA: 0x0000F8F0 File Offset: 0x0000DAF0
		private IUIElemento dibujaLabelCortoLabelLargoPar(IUIPanel panel, MemberInfo fieldInfo, object modelOwner, int index, IEnumerable<Attribute> attibutos, DibujadorDynamico.ExtraData extradata)
		{
			if (!(attibutos.FirstOrDefault((Attribute a) => a is LabelCortoLabelLargoParAttribute) is LabelCortoLabelLargoParAttribute))
			{
				return null;
			}
			UIElemento uielemento = Object.Instantiate<LabelParElement>(MapaSingleton<MapaSingletonDeUIPrefabs>.instance.labelConrtoLAbelLargoPar);
			this.PostDibujarElemento1(panel, uielemento, fieldInfo, attibutos, modelOwner, index, false, extradata);
			this.PostDibujarElemento2(panel, uielemento, fieldInfo, attibutos, modelOwner, extradata);
			return uielemento;
		}

		// Token: 0x060003E6 RID: 998 RVA: 0x0000F95C File Offset: 0x0000DB5C
		private IUIElemento dibujaLabelCortoLevel(IUIPanel panel, MemberInfo fieldInfo, object modelOwner, int index, IEnumerable<Attribute> attibutos, DibujadorDynamico.ExtraData extradata)
		{
			if (!(attibutos.FirstOrDefault((Attribute a) => a is LevelLabelCortoAttribute) is LevelLabelCortoAttribute))
			{
				return null;
			}
			UIElemento uielemento = Object.Instantiate<LevelElementToolTip>(MapaSingleton<MapaSingletonDeUIPrefabs>.instance.levelLabelLargo);
			this.PostDibujarElemento1(panel, uielemento, fieldInfo, attibutos, modelOwner, index, false, extradata);
			this.PostDibujarElemento2(panel, uielemento, fieldInfo, attibutos, modelOwner, extradata);
			return uielemento;
		}

		// Token: 0x060003E7 RID: 999 RVA: 0x0000F9C8 File Offset: 0x0000DBC8
		private IUIElemento dibujaImagen(IUIPanel panel, MemberInfo fieldInfo, object modelOwner, int index, IEnumerable<Attribute> attibutos, DibujadorDynamico.ExtraData extradata)
		{
			if (!(attibutos.FirstOrDefault((Attribute a) => a is ImagenAttribute) is ImagenAttribute))
			{
				return null;
			}
			ImagenFieldElement imagenFieldElement = Object.Instantiate<ImagenFieldElement>(MapaSingleton<MapaSingletonDeUIPrefabs>.instance.Imagen);
			this.PostDibujarElemento1(panel, imagenFieldElement, fieldInfo, attibutos, modelOwner, index, false, extradata);
			this.PostDibujarElemento2(panel, imagenFieldElement, fieldInfo, attibutos, modelOwner, extradata);
			return imagenFieldElement;
		}

		// Token: 0x060003E8 RID: 1000 RVA: 0x0000FA34 File Offset: 0x0000DC34
		private IUIElemento dibujaInfoLabel(IUIPanel panel, MemberInfo fieldInfo, object modelOwner, int index, IEnumerable<Attribute> attibutos, DibujadorDynamico.ExtraData extradata)
		{
			InfoLabelAttribute infoLabelAttribute = attibutos.FirstOrDefault((Attribute a) => a is InfoLabelAttribute) as InfoLabelAttribute;
			if (infoLabelAttribute == null)
			{
				return null;
			}
			LabelParElement labelParElement = Object.Instantiate<LabelParElement>(MapaSingleton<MapaSingletonDeUIPrefabs>.instance.infoLabel);
			if (!string.IsNullOrWhiteSpace(infoLabelAttribute.separador))
			{
				labelParElement.separador.text = infoLabelAttribute.separador;
			}
			this.PostDibujarElemento1(panel, labelParElement, fieldInfo, attibutos, modelOwner, index, false, extradata);
			this.PostDibujarElemento2(panel, labelParElement, fieldInfo, attibutos, modelOwner, extradata);
			return labelParElement;
		}

		// Token: 0x060003E9 RID: 1001 RVA: 0x0000FAC0 File Offset: 0x0000DCC0
		private IUIElemento dibujaColorToggle(IUIPanel panel, MemberInfo fieldInfo, object modelOwner, int index, IEnumerable<Attribute> attibutos, DibujadorDynamico.ExtraData extradata)
		{
			UIElemento uielemento = Object.Instantiate<UIElemento>(MapaSingleton<MapaSingletonDeUIPrefabs>.instance.colorToggle);
			this.PostDibujarElemento1(panel, uielemento, fieldInfo, attibutos, modelOwner, index, false, extradata);
			this.PostDibujarElemento2(panel, uielemento, fieldInfo, attibutos, modelOwner, extradata);
			return uielemento;
		}

		// Token: 0x060003EA RID: 1002 RVA: 0x0000FB00 File Offset: 0x0000DD00
		private void PostDibujarElemento1(IUIPanel panel, UIElemento elmento, MemberInfo fieldInfo, IEnumerable<Attribute> attr, object modelOwner, int index, bool useElementDespAsDefault = false, DibujadorDynamico.ExtraData extradata = null)
		{
			this.setSize(modelOwner, elmento, attr, extradata.paraType.miembrosV2, null);
			if (!this.addLabelOld(elmento, fieldInfo, attr))
			{
				this.addLabel(elmento, fieldInfo, modelOwner, index, attr, extradata);
			}
			this.addLabelMultiOld(elmento, fieldInfo, attr);
			this.addLabelMulti(elmento, fieldInfo, modelOwner, index, attr, extradata);
			this.addDescripcionOld(elmento, fieldInfo, attr, useElementDespAsDefault);
			this.addDescripcion(elmento, fieldInfo, modelOwner, index, attr, extradata);
			this.addDescripcionSimple(elmento, fieldInfo, modelOwner, index, attr, extradata);
			this.addConfirmable(elmento, fieldInfo, attr, modelOwner, extradata);
			this.addAccionName(elmento, attr);
			this.addEnabledState(elmento, attr);
			this.setLayout(elmento, attr);
		}

		// Token: 0x060003EB RID: 1003 RVA: 0x0000FBB0 File Offset: 0x0000DDB0
		private void PostDibujarElemento2(IUIPanel panel, UIElemento elmento, MemberInfo fieldInfo, IEnumerable<Attribute> attr, object modelOwner, DibujadorDynamico.ExtraData extradata)
		{
			this.addUIElementoAPanel(panel, elmento, attr, null, false);
			this.AddExtraDataAElemento(elmento, fieldInfo, modelOwner, extradata);
		}

		// Token: 0x060003EC RID: 1004 RVA: 0x0000FBCA File Offset: 0x0000DDCA
		private void PostDibujarElemento2(IUIPanel panel, Transform targetToAddTo, UIElemento elmento, MemberInfo fieldInfo, object modelOwner, DibujadorDynamico.ExtraData extradata)
		{
			this.addUIElementoAPanel(targetToAddTo, elmento, false);
			this.AddExtraDataAElemento(elmento, fieldInfo, modelOwner, extradata);
		}

		// Token: 0x060003ED RID: 1005 RVA: 0x0000FBE4 File Offset: 0x0000DDE4
		private void SetLinkedElements(IDictionary<IUIElemento, List<IUIElemento>> elementos, IUIElemento elmento)
		{
			IUIElementoConInvertLinkedElements iuielementoConInvertLinkedElements = elmento as IUIElementoConInvertLinkedElements;
			if (iuielementoConInvertLinkedElements == null)
			{
				return;
			}
			List<IUIElemento> list;
			if (!elementos.TryGetValue(elmento, out list))
			{
				return;
			}
			iuielementoConInvertLinkedElements.InvertLinked = list;
		}

		// Token: 0x060003EE RID: 1006 RVA: 0x0000FC10 File Offset: 0x0000DE10
		private void BindElemento(IUIPanel panel, IUIElemento elmento, MemberInfo fieldInfo, string modeloName, object valor, object modelOwner, bool ignoreValue, bool isListItem, IEnumerable<Attribute> attr)
		{
			IUIElementoConValorSoloEscritura iuielementoConValorSoloEscritura = elmento as IUIElementoConValorSoloEscritura;
			if (iuielementoConValorSoloEscritura == null || ignoreValue)
			{
				this.addModel(elmento, fieldInfo, modeloName, isListItem, attr);
			}
			else
			{
				this.addModel(iuielementoConValorSoloEscritura, fieldInfo, modeloName, valor, isListItem, attr);
			}
			this.SecAddModel(elmento, fieldInfo, attr);
		}

		// Token: 0x060003EF RID: 1007 RVA: 0x0000FC58 File Offset: 0x0000DE58
		private void AddExtraDataAElemento(IUIElemento elemento, MemberInfo fieldInfo, object modelOwner, DibujadorDynamico.ExtraData extradata)
		{
			if (extradata == null)
			{
				return;
			}
			Type type = modelOwner.GetType();
			IUIElementoConExtraData iuielementoConExtraData = elemento as IUIElementoConExtraData;
			if (iuielementoConExtraData != null)
			{
				List<Func<object>> list = new List<Func<object>>();
				if (extradata.paraModel.dataDelegates.ContainsKey(new ValueTuple<object, string>(modelOwner, fieldInfo.Name)))
				{
					list.AddRange(extradata.paraModel.dataDelegates[new ValueTuple<object, string>(modelOwner, fieldInfo.Name)]);
				}
				if (extradata.paraModel.dataDelegates.ContainsKey(new ValueTuple<object, string>(modelOwner, "TODOS*TODOS*TODOS")))
				{
					list.AddRange(extradata.paraModel.dataDelegates[new ValueTuple<object, string>(modelOwner, "TODOS*TODOS*TODOS")]);
				}
				iuielementoConExtraData.extradata = list;
			}
			IUIElementoActivable iuielementoActivable = elemento as IUIElementoActivable;
			if (iuielementoActivable != null)
			{
				List<Func<bool>> list2 = new List<Func<bool>>();
				if (extradata.paraType.activatedDelegates.ContainsKey(new ValueTuple<Type, string>(type, fieldInfo.Name)))
				{
					list2.AddRange(extradata.paraType.activatedDelegates[new ValueTuple<Type, string>(type, fieldInfo.Name)]);
				}
				if (extradata.paraType.activatedDelegates.ContainsKey(new ValueTuple<Type, string>(type, "TODOS*TODOS*TODOS")))
				{
					list2.AddRange(extradata.paraType.activatedDelegates[new ValueTuple<Type, string>(type, "TODOS*TODOS*TODOS")]);
				}
				iuielementoActivable.canBeActivatedDelegates = list2;
			}
		}

		// Token: 0x060003F0 RID: 1008 RVA: 0x0000FDB0 File Offset: 0x0000DFB0
		private BotonElementBase DibujarBotonDePanel(MethodInfo info, object modelOwner, IUIPanel panel, Transform panelParaBotones, IEnumerable<Attribute> attr, DibujadorDynamico.ExtraData extradata)
		{
			if (!(attr.FirstOrDefault((Attribute a) => a is ClickableAttribute) is ClickableAttribute))
			{
				return null;
			}
			BotonElement botonElement = Object.Instantiate<BotonElement>(MapaSingleton<MapaSingletonDeUIPrefabs>.instance.botonDePanel);
			DibujadorDynamico.SetDelegadoAClickable(botonElement, info, panel, modelOwner);
			this.PostDibujarElemento1(panel, botonElement, info, attr, modelOwner, -1, false, extradata);
			this.PostDibujarElemento2(panel, panelParaBotones, botonElement, info, modelOwner, extradata);
			return botonElement;
		}

		// Token: 0x060003F1 RID: 1009 RVA: 0x0000FE24 File Offset: 0x0000E024
		private BotonElementBase DibujarBotonDePanelConfirmable(MethodInfo info, object modelOwner, IUIPanel panel, Transform panelParaBotones, IEnumerable<Attribute> attr, DibujadorDynamico.ExtraData extradata)
		{
			if (!(attr.FirstOrDefault((Attribute a) => a is ClickableAttribute) is ClickableAttribute))
			{
				return null;
			}
			BotonElementConfirmable botonElementConfirmable = Object.Instantiate<BotonElementConfirmable>(MapaSingleton<MapaSingletonDeUIPrefabs>.instance.botonDePanelConfirmable);
			DibujadorDynamico.SetDelegadoAClickable(botonElementConfirmable, info, panel, modelOwner);
			this.PostDibujarElemento1(panel, botonElementConfirmable, info, attr, modelOwner, -1, false, extradata);
			this.PostDibujarElemento2(panel, panelParaBotones, botonElementConfirmable, info, modelOwner, extradata);
			return botonElementConfirmable;
		}

		// Token: 0x060003F2 RID: 1010 RVA: 0x0000FE98 File Offset: 0x0000E098
		private void addModel(IUIElementoConValorSoloEscritura instanciado, MemberInfo info, string modeloName, object initialValue, bool isListItem, IEnumerable<Attribute> attr)
		{
			if (instanciado.isBinded)
			{
				throw new InvalidOperationException();
			}
			instanciado.Bind(modeloName, info.GetUnderlyingType(), initialValue, isListItem);
		}

		// Token: 0x060003F3 RID: 1011 RVA: 0x0000FEB9 File Offset: 0x0000E0B9
		private void addModel(IUIElemento instanciado, MemberInfo info, string modeloName, bool isListItem, IEnumerable<Attribute> attr)
		{
			if (instanciado.isBinded)
			{
				throw new InvalidOperationException();
			}
			instanciado.Bind(modeloName, info.GetUnderlyingType(), isListItem);
		}

		// Token: 0x060003F4 RID: 1012 RVA: 0x0000FED8 File Offset: 0x0000E0D8
		private void SecAddModel(IUIElemento instanciado, MemberInfo info, IEnumerable<Attribute> attr)
		{
			IUIElementoSecondaryBindable iuielementoSecondaryBindable = instanciado as IUIElementoSecondaryBindable;
			if (iuielementoSecondaryBindable == null)
			{
				return;
			}
			SecondaryModelAttribute secondaryModelAttribute = attr.FirstOrDefault((Attribute a) => a is SecondaryModelAttribute) as SecondaryModelAttribute;
			if (secondaryModelAttribute == null)
			{
				return;
			}
			Func<object> getter = SecondaryModelAttribute.GetGetter(secondaryModelAttribute, null);
			iuielementoSecondaryBindable.SecondaryBind(secondaryModelAttribute.member, secondaryModelAttribute.type, secondaryModelAttribute.index, getter);
		}

		// Token: 0x060003F5 RID: 1013 RVA: 0x0000FF40 File Offset: 0x0000E140
		private void addConfirmable(UIElemento elemento, MemberInfo member, IEnumerable<Attribute> atributes, object modelOwner, DibujadorDynamico.ExtraData extradata)
		{
			IUIElementoConfirmable iuielementoConfirmable = elemento as IUIElementoConfirmable;
			if (iuielementoConfirmable == null)
			{
				return;
			}
			ClickableConfirmableAttribute clickableConfirmableAttribute = atributes.FirstOrDefault((Attribute a) => a is ClickableConfirmableAttribute) as ClickableConfirmableAttribute;
			if (clickableConfirmableAttribute == null)
			{
				return;
			}
			TextoLocalizadoAttribute currentLocalizationOrDefault = this.GetCurrentLocalizationOrDefault<ConfirmablePreguntaAttribute>(atributes, member.Name, "US");
			if (currentLocalizationOrDefault == null)
			{
				return;
			}
			iuielementoConfirmable.confirmar = clickableConfirmableAttribute.confirmar;
			iuielementoConfirmable.confirmarText = currentLocalizationOrDefault.text;
			if (extradata != null && extradata.paraType.confirmables.ContainsKey(new ValueTuple<Type, string>(modelOwner.GetType(), member.Name)))
			{
				iuielementoConfirmable.confirmarDelegate = extradata.paraType.confirmables[new ValueTuple<Type, string>(modelOwner.GetType(), member.Name)];
			}
		}

		// Token: 0x060003F6 RID: 1014 RVA: 0x00010008 File Offset: 0x0000E208
		private void addEnabledState(UIElemento elemento, IEnumerable<Attribute> atributes)
		{
			IUIElementoActivable iuielementoActivable = elemento as IUIElementoActivable;
			if (iuielementoActivable == null)
			{
				return;
			}
			DynamicUIElementAttribute dynamicUIElementAttribute = atributes.FirstOrDefault((Attribute a) => a is DynamicUIElementAttribute) as DynamicUIElementAttribute;
			if (atributes.FirstOrDefault((Attribute a) => a is UIElementDisabledAttribute) is UIElementDisabledAttribute)
			{
				iuielementoActivable.activatedInitialState = false;
				return;
			}
			iuielementoActivable.activatedInitialState = ((dynamicUIElementAttribute != null) ? new bool?(dynamicUIElementAttribute.enabled) : null).GetValueOrDefault(true);
		}

		// Token: 0x060003F7 RID: 1015 RVA: 0x000100A8 File Offset: 0x0000E2A8
		private void setLayout(UIElemento elemento, IEnumerable<Attribute> atributes)
		{
			IBaseLayoutAttribute baseLayoutAttribute = this.TryGetAttributeLast<IBaseLayoutAttribute>(atributes);
			DibujadorDynamico.SetUILabelAtributosToElement(elemento, baseLayoutAttribute);
		}

		// Token: 0x060003F8 RID: 1016 RVA: 0x000100C4 File Offset: 0x0000E2C4
		private void addAccionName(UIElemento elemento, IEnumerable<Attribute> atributes)
		{
			IUIElementoConAccionName iuielementoConAccionName = elemento as IUIElementoConAccionName;
			if (iuielementoConAccionName == null)
			{
				return;
			}
			AccionNameAttribute accionNameAttribute = atributes.FirstOrDefault((Attribute a) => a is AccionNameAttribute) as AccionNameAttribute;
			if (accionNameAttribute == null)
			{
				return;
			}
			iuielementoConAccionName.accionName = accionNameAttribute.nombre;
		}

		// Token: 0x060003F9 RID: 1017 RVA: 0x00010118 File Offset: 0x0000E318
		private void setSize(object model, UIElemento element, IEnumerable<Attribute> atributes, IReadOnlyList<MemberInfo> miembros, IElementLayoutAttribute overrideingLayout)
		{
			IElementLayoutAttribute elementLayoutAttribute = overrideingLayout ?? this.GetAttribute<IElementLayoutAttribute>(atributes);
			HeightDinamicoAttribute attribute = this.GetAttribute<HeightDinamicoAttribute>(atributes);
			this.setSize(elementLayoutAttribute, element.transform, model, attribute, miembros);
		}

		// Token: 0x060003FA RID: 1018 RVA: 0x0001014C File Offset: 0x0000E34C
		private void setPanelAlyoutGroupAttributes(object model, IUIPanel panel, IEnumerable<Attribute> atributes, IReadOnlyList<MemberInfo> miembros, IPanelLayoutAttribute overrideingLayout)
		{
			IPanelLayoutAttribute atributo = overrideingLayout ?? this.GetAttribute<IPanelLayoutAttribute>(atributes);
			if (atributo == null)
			{
				return;
			}
			List<HorizontalOrVerticalLayoutGroup> list = new List<HorizontalOrVerticalLayoutGroup>();
			List<LayoutElement> list2 = new List<LayoutElement>();
			for (int i = 0; i < panel.getParentCount; i++)
			{
				HorizontalOrVerticalLayoutGroup horizontalOrVerticalLayoutGroup = null;
				LayoutElement layoutElement = null;
				Transform parentPara = panel.GetParentPara(i);
				if (((parentPara != null) ? new bool?(parentPara.TryGetComponent<HorizontalOrVerticalLayoutGroup>(out horizontalOrVerticalLayoutGroup)) : null).GetValueOrDefault())
				{
					list.Add(horizontalOrVerticalLayoutGroup);
				}
				if (((parentPara != null) ? new bool?(parentPara.TryGetComponent<LayoutElement>(out layoutElement)) : null).GetValueOrDefault())
				{
					list2.Add(layoutElement);
				}
			}
			if (atributo.controlChildWidth != null)
			{
				list.ForEach(delegate(HorizontalOrVerticalLayoutGroup lg)
				{
					lg.childControlWidth = atributo.controlChildWidth.Value;
				});
			}
			if (atributo.controlChildHeight != null)
			{
				list.ForEach(delegate(HorizontalOrVerticalLayoutGroup lg)
				{
					lg.childControlHeight = atributo.controlChildHeight.Value;
				});
			}
			if (atributo.childForceExpandWidth != null)
			{
				list.ForEach(delegate(HorizontalOrVerticalLayoutGroup lg)
				{
					lg.childForceExpandWidth = atributo.childForceExpandWidth.Value;
				});
			}
			if (atributo.childForceExpandHeight != null)
			{
				list.ForEach(delegate(HorizontalOrVerticalLayoutGroup lg)
				{
					lg.childForceExpandHeight = atributo.childForceExpandHeight.Value;
				});
			}
			if (atributo.flexibleHeight != null)
			{
				list2.ForEach(delegate(LayoutElement le)
				{
					le.flexibleHeight = atributo.flexibleHeight.Value;
				});
			}
			if (atributo.flexibleWidth != null)
			{
				list2.ForEach(delegate(LayoutElement le)
				{
					le.flexibleWidth = atributo.flexibleWidth.Value;
				});
			}
			RectTransform rectTransform = panel.transform as RectTransform;
			if (atributo.posXByUser)
			{
				Vector2 anchoredPosition = rectTransform.anchoredPosition;
				anchoredPosition.x = (float)atributo.posX;
				rectTransform.anchoredPosition = anchoredPosition;
			}
			if (atributo.posYByUser)
			{
				Vector2 anchoredPosition2 = rectTransform.anchoredPosition;
				anchoredPosition2.y = (float)atributo.posY;
				rectTransform.anchoredPosition = anchoredPosition2;
			}
		}

		// Token: 0x060003FB RID: 1019 RVA: 0x00010368 File Offset: 0x0000E568
		private void setPanelAttributes(object model, IUIPanel panel, IEnumerable<Attribute> atributes, IReadOnlyList<MemberInfo> miembros)
		{
			IPanelAttribute attribute = this.GetAttribute<IPanelAttribute>(atributes);
			if (attribute == null)
			{
				return;
			}
			Image component = panel.transform.GetComponent<Image>();
			if (component == null)
			{
				return;
			}
			if (attribute.backgroundTypeByUser)
			{
				switch (attribute.backgroundType)
				{
				case PanelBackgroundType.None:
					component.sprite = null;
					break;
				case PanelBackgroundType.selection:
					component.sprite = MapaSingleton<MapaSingletonDeUIPrefabs>.instance.panelBackgroundsSelection;
					break;
				case PanelBackgroundType.window:
					component.sprite = MapaSingleton<MapaSingletonDeUIPrefabs>.instance.panelBackgroundsWindow;
					break;
				default:
					throw new ArgumentOutOfRangeException(attribute.backgroundType.ToString());
				}
			}
			if (attribute.backgroundColorByUser)
			{
				float a = component.color.a;
				PanelBackgroundColor backgroundColor = attribute.backgroundColor;
				if (backgroundColor != PanelBackgroundColor.black)
				{
					if (backgroundColor != PanelBackgroundColor.white)
					{
						throw new ArgumentOutOfRangeException(attribute.backgroundColor.ToString());
					}
					Color white = Color.white;
					white.a = a;
					component.color = white;
				}
				else
				{
					Color black = Color.black;
					black.a = a;
					component.color = black;
				}
			}
			if (attribute.backgroundAlphaByUser)
			{
				Color color = component.color;
				color.a = attribute.backgroundAlpha;
				component.color = color;
			}
		}

		// Token: 0x060003FC RID: 1020 RVA: 0x000104A0 File Offset: 0x0000E6A0
		private void setSize(IElementLayoutAttribute sisable, Transform element, object model, HeightDinamicoAttribute dinamicHeight, IReadOnlyList<MemberInfo> miembros)
		{
			if (sisable == null)
			{
				return;
			}
			int? num = null;
			if (dinamicHeight != null)
			{
				string para = dinamicHeight.dinamicoMethodTarget;
				MethodInfo methodInfo = miembros.FirstOrDefault((MemberInfo m) => m.Name == para) as MethodInfo;
				if (methodInfo != null)
				{
					if (methodInfo.GetParameters().Length != 0)
					{
						Debug.LogException(new NotSupportedException("metodo debe tener zero parametros. en metodo: " + methodInfo.Name));
					}
					if (methodInfo.ReturnType != typeof(int))
					{
						Debug.LogException(new NotSupportedException("Se necesita Return type tipo :" + typeof(int).Name + ". en metodo: " + methodInfo.Name));
					}
					HeightDinamicoAttribute.HeightDinamicaHandler heightDinamicaHandler;
					try
					{
						heightDinamicaHandler = (HeightDinamicoAttribute.HeightDinamicaHandler)methodInfo.CreateDelegate(typeof(HeightDinamicoAttribute.HeightDinamicaHandler), model);
					}
					catch (Exception ex)
					{
						Debug.LogException(new NotSupportedException(ex.Message, ex));
						heightDinamicaHandler = null;
					}
					num = ((heightDinamicaHandler != null) ? new int?(heightDinamicaHandler()) : null);
				}
			}
			RectTransform component = element.GetComponent<RectTransform>();
			LayoutElement component2 = element.GetComponent<LayoutElement>();
			Transform parent = element.transform.parent;
			LayoutElement layoutElement = ((parent != null) ? parent.GetComponent<LayoutElement>() : null);
			if (sisable.scaleModByUser)
			{
				component.localScale *= sisable.scaleMod;
			}
			bool flag = sisable.heightByUser || num != null;
			int num2 = ((num != null) ? num.Value : sisable.height);
			if (flag)
			{
				component.SetSizeWithCurrentAnchors(RectTransform.Axis.Vertical, (float)num2);
				if (component2 != null)
				{
					component2.preferredHeight = (component2.minHeight = (float)num2);
					if (!sisable.unlockFlexibleIfHeightWasSet)
					{
						component2.flexibleHeight = 0f;
					}
				}
				if (layoutElement && !sisable.unlockParentFlexibleIfHeightWasSet)
				{
					layoutElement.flexibleHeight = 0f;
				}
			}
			if (sisable.widthByUser)
			{
				component.SetSizeWithCurrentAnchors(RectTransform.Axis.Horizontal, (float)sisable.width);
				if (component2 != null)
				{
					component2.preferredWidth = (component2.minWidth = (float)sisable.width);
					if (!sisable.unlockFlexibleIfWidthWasSet)
					{
						component2.flexibleWidth = 0f;
					}
				}
				if (layoutElement && !sisable.unlockParentFlexibleIfWidthWasSet)
				{
					layoutElement.flexibleWidth = 0f;
				}
			}
			if (sisable.heightModByUser)
			{
				if (component2 != null)
				{
					component2.preferredHeight *= sisable.heightMod;
					component2.minHeight *= sisable.heightMod;
					if (!sisable.unlockFlexibleIfHeightWasSet)
					{
						component2.flexibleHeight = 0f;
					}
				}
				if (layoutElement && !sisable.unlockParentFlexibleIfHeightWasSet)
				{
					layoutElement.flexibleHeight = 0f;
				}
			}
			if (sisable.widthModByUser)
			{
				if (component2 != null)
				{
					component2.preferredWidth *= sisable.widthMod;
					component2.minWidth *= sisable.widthMod;
					if (!sisable.unlockFlexibleIfWidthWasSet)
					{
						component2.flexibleWidth = 0f;
					}
				}
				if (layoutElement && !sisable.unlockParentFlexibleIfWidthWasSet)
				{
					layoutElement.flexibleWidth = 0f;
				}
			}
		}

		// Token: 0x060003FD RID: 1021 RVA: 0x000107C4 File Offset: 0x0000E9C4
		private bool addLabelOld(UIElemento elemento, MemberInfo member, IEnumerable<Attribute> atributes)
		{
			IUIElementoConLabel iuielementoConLabel = elemento as IUIElementoConLabel;
			if (iuielementoConLabel == null || iuielementoConLabel.label == null)
			{
				return false;
			}
			TextoLocalizadoAttribute currentLocalization = this.GetCurrentLocalization<LabelAttribute>(atributes);
			if (currentLocalization != null)
			{
				if (!string.IsNullOrWhiteSpace(currentLocalization.text))
				{
					iuielementoConLabel.label.text = currentLocalization.text;
				}
				DibujadorDynamico.SetUILabelAtributosToFont(iuielementoConLabel, iuielementoConLabel.label, this.TryGetAttributeFirst<IFontAttribute>(atributes), this.TryGetAttributeLast<IBaseLayoutAttribute>(atributes));
				return true;
			}
			return false;
		}

		// Token: 0x060003FE RID: 1022 RVA: 0x00010834 File Offset: 0x0000EA34
		private void addLabel(UIElemento elemento, MemberInfo member, object modelOwner, int index, IEnumerable<Attribute> atributes, DibujadorDynamico.ExtraData extradata)
		{
			IUIElementoConLabel iuielementoConLabel = elemento as IUIElementoConLabel;
			if (iuielementoConLabel == null || iuielementoConLabel.label == null)
			{
				return;
			}
			TextoLocalizadoAttribute currentLocalization = this.GetCurrentLocalization<LabelLocalizadoAttribute>(atributes);
			TValleUILocalTextAttribute currentLocalizationModding;
			LabelDinamicoAttribute.LabelDinamicaHandler labelDinamicaHandler;
			if (currentLocalization != null)
			{
				if (!string.IsNullOrWhiteSpace(currentLocalization.text))
				{
					iuielementoConLabel.label.text = currentLocalization.text;
				}
			}
			else if ((currentLocalizationModding = this.GetCurrentLocalizationModding<LabelAttribute>(atributes)) != null)
			{
				if (!string.IsNullOrWhiteSpace(currentLocalizationModding.text))
				{
					iuielementoConLabel.label.text = currentLocalizationModding.text;
				}
			}
			else if (extradata != null && member != null && modelOwner != null && extradata.paraType.labelDinamicos.TryGetValue(new ValueTuple<Type, string>(modelOwner.GetType(), member.Name), out labelDinamicaHandler) && labelDinamicaHandler != null)
			{
				string text = labelDinamicaHandler();
				if (!string.IsNullOrWhiteSpace(text))
				{
					iuielementoConLabel.label.text = text;
				}
			}
			else
			{
				FieldInfo fieldInfo = member as FieldInfo;
				if (fieldInfo != null && !fieldInfo.IsCollection())
				{
					string text2;
					try
					{
						text2 = fieldInfo.GetValue(modelOwner).ToString();
					}
					catch (Exception ex)
					{
						throw ex;
					}
					if (!string.IsNullOrWhiteSpace(text2))
					{
						iuielementoConLabel.label.text = text2;
					}
				}
			}
			IFontAttribute fontAttribute = this.TryGetAttributeFirst<IFontAttribute>(atributes);
			IBaseLayoutAttribute baseLayoutAttribute = this.TryGetAttributeLast<IBaseLayoutAttribute>(atributes);
			DibujadorDynamico.SetUILabelAtributosToFont(iuielementoConLabel, iuielementoConLabel.label, fontAttribute, baseLayoutAttribute);
		}

		// Token: 0x060003FF RID: 1023 RVA: 0x00010990 File Offset: 0x0000EB90
		private void addLabelMultiOld(UIElemento elemento, MemberInfo member, IEnumerable<Attribute> atributes)
		{
			IUIElementoConMultiLabel iuielementoConMultiLabel = elemento as IUIElementoConMultiLabel;
			if (iuielementoConMultiLabel == null)
			{
				return;
			}
			IList<TextoLocalizadoAttribute> currentLocalizationsOrDefault = this.GetCurrentLocalizationsOrDefault<LabelAttribute>(atributes, member.Name, "US");
			int num = Mathf.Min(currentLocalizationsOrDefault.Count, iuielementoConMultiLabel.labels.Count);
			for (int i = 0; i < num; i++)
			{
				TextMeshProUGUI textMeshProUGUI = iuielementoConMultiLabel.labels[i];
				TextoLocalizadoAttribute textoLocalizadoAttribute = currentLocalizationsOrDefault[i];
				if (textoLocalizadoAttribute != null)
				{
					if (!string.IsNullOrWhiteSpace(textoLocalizadoAttribute.text))
					{
						textMeshProUGUI.text = textoLocalizadoAttribute.text;
					}
					DibujadorDynamico.SetUILabelAtributosToFont(iuielementoConMultiLabel, textMeshProUGUI, this.TryGetAttributeFirst<IFontAttribute>(atributes), this.TryGetAttributeLast<IBaseLayoutAttribute>(atributes));
				}
			}
		}

		// Token: 0x06000400 RID: 1024 RVA: 0x00010A2C File Offset: 0x0000EC2C
		private void addLabelMulti(UIElemento elemento, MemberInfo member, object modelOwner, int index, IEnumerable<Attribute> atributes, DibujadorDynamico.ExtraData extradata)
		{
			IUIElementoConMultiLabel iuielementoConMultiLabel = elemento as IUIElementoConMultiLabel;
			if (iuielementoConMultiLabel == null)
			{
				return;
			}
			IList<TextoLocalizadoAttribute> currentLocalizations = this.GetCurrentLocalizations<LabelLocalizadoAttribute>(atributes);
			if (currentLocalizations != null && currentLocalizations.Count > 0)
			{
				int num = Mathf.Min(currentLocalizations.Count, iuielementoConMultiLabel.labels.Count);
				for (int i = 0; i < num; i++)
				{
					TextMeshProUGUI textMeshProUGUI = iuielementoConMultiLabel.labels[i];
					TextoLocalizadoAttribute textoLocalizadoAttribute = currentLocalizations[i];
					if (textoLocalizadoAttribute != null && !string.IsNullOrWhiteSpace(textoLocalizadoAttribute.text))
					{
						textMeshProUGUI.text = textoLocalizadoAttribute.text;
					}
				}
			}
			for (int j = 0; j < iuielementoConMultiLabel.labels.Count; j++)
			{
				DibujadorDynamico.SetUILabelAtributosToFont(iuielementoConMultiLabel, iuielementoConMultiLabel.labels[j], this.TryGetAttributeAt<IFontAttribute>(atributes, j), this.TryGetAttributeAt<IBaseLayoutAttribute>(atributes, j));
			}
		}

		// Token: 0x06000401 RID: 1025 RVA: 0x00010AF4 File Offset: 0x0000ECF4
		private void addDescripcionOld(UIElemento elemento, MemberInfo member, IEnumerable<Attribute> atributes, bool useElementDespAsDefault)
		{
			IUIElementoConDescripcion iuielementoConDescripcion = elemento as IUIElementoConDescripcion;
			if (iuielementoConDescripcion == null)
			{
				return;
			}
			IList<TextoLocalizadoAttribute> currentLocalizationsOrDefault = this.GetCurrentLocalizationsOrDefault<DescripcionAttribute>(atributes, useElementDespAsDefault ? iuielementoConDescripcion.descripcion.text : string.Empty, "US");
			if (currentLocalizationsOrDefault.Count > 0)
			{
				string text = string.Empty;
				foreach (TextoLocalizadoAttribute textoLocalizadoAttribute in currentLocalizationsOrDefault)
				{
					if (!string.IsNullOrWhiteSpace(text))
					{
						text += "\n";
					}
					if (!string.IsNullOrWhiteSpace(textoLocalizadoAttribute.text))
					{
						text += textoLocalizadoAttribute.text;
					}
				}
				iuielementoConDescripcion.descripcion.text = text;
				DibujadorDynamico.SetUILabelAtributosToFont(iuielementoConDescripcion, iuielementoConDescripcion.descripcion, currentLocalizationsOrDefault.FirstOrDefault<TextoLocalizadoAttribute>() as IFontAttribute, this.TryGetAttributeLast<IBaseLayoutAttribute>(atributes));
			}
		}

		// Token: 0x06000402 RID: 1026 RVA: 0x00010BD0 File Offset: 0x0000EDD0
		private void addDescripcion(UIElemento elemento, MemberInfo member, object modelOwner, int index, IEnumerable<Attribute> atributes, DibujadorDynamico.ExtraData extradata)
		{
			IUIElementoConDescripcion iuielementoConDescripcion = elemento as IUIElementoConDescripcion;
			if (iuielementoConDescripcion == null)
			{
				return;
			}
			string text = string.Empty;
			IList<TextoLocalizadoAttribute> currentLocalizations = this.GetCurrentLocalizations<DescripcionLocalizadoAttribute>(atributes);
			if (currentLocalizations != null && currentLocalizations.Count > 0)
			{
				IFontAttribute fontAttribute = this.TryGetAttributeFirst<IFontAttribute>(atributes);
				IBaseLayoutAttribute baseLayoutAttribute = this.TryGetAttributeLast<IBaseLayoutAttribute>(atributes);
				foreach (TextoLocalizadoAttribute textoLocalizadoAttribute in currentLocalizations)
				{
					if (!string.IsNullOrWhiteSpace(text))
					{
						text += "\n";
					}
					if (!string.IsNullOrWhiteSpace(textoLocalizadoAttribute.text))
					{
						text += textoLocalizadoAttribute.text;
					}
				}
				DibujadorDynamico.SetUILabelAtributosToFont(iuielementoConDescripcion, iuielementoConDescripcion.descripcion, fontAttribute, baseLayoutAttribute);
			}
			IList<TValleUILocalTextAttribute> currentLocalizationsModding;
			if ((currentLocalizationsModding = this.GetCurrentLocalizationsModding<LabelAttribute>(atributes)) != null && currentLocalizationsModding.Count > 0)
			{
				IFontAttribute fontAttribute2 = this.TryGetAttributeFirst<IFontAttribute>(atributes);
				IBaseLayoutAttribute baseLayoutAttribute2 = this.TryGetAttributeLast<IBaseLayoutAttribute>(atributes);
				foreach (TValleUILocalTextAttribute tvalleUILocalTextAttribute in currentLocalizationsModding)
				{
					if (!string.IsNullOrWhiteSpace(text))
					{
						text += "\n";
					}
					if (!string.IsNullOrWhiteSpace(tvalleUILocalTextAttribute.text))
					{
						text += tvalleUILocalTextAttribute.text;
					}
				}
				DibujadorDynamico.SetUILabelAtributosToFont(iuielementoConDescripcion, iuielementoConDescripcion.descripcion, fontAttribute2, baseLayoutAttribute2);
			}
			if (extradata != null && member != null && modelOwner != null)
			{
				ValueTuple<Type, string> valueTuple = new ValueTuple<Type, string>(modelOwner.GetType(), member.Name);
				List<DescripcionDinamicaAttribute.DescripcionDinamicaHandler> list;
				if (extradata.paraType.descripcionesDinamicas.TryGetValue(valueTuple, out list))
				{
					foreach (DescripcionDinamicaAttribute.DescripcionDinamicaHandler descripcionDinamicaHandler in list)
					{
						if (descripcionDinamicaHandler != null)
						{
							if (!string.IsNullOrWhiteSpace(text))
							{
								text += "\n";
							}
							float num;
							string text2 = descripcionDinamicaHandler(out num, index);
							if (!string.IsNullOrWhiteSpace(text2))
							{
								text += text2;
							}
						}
					}
				}
			}
			if (!string.IsNullOrWhiteSpace(text))
			{
				iuielementoConDescripcion.descripcion.text = text;
			}
		}

		// Token: 0x06000403 RID: 1027 RVA: 0x00010E00 File Offset: 0x0000F000
		private void addDescripcionSimple(UIElemento elemento, MemberInfo member, object modelOwner, int index, IEnumerable<Attribute> atributes, DibujadorDynamico.ExtraData extradata)
		{
			IUIElementoConDescripcionSimple iuielementoConDescripcionSimple = elemento as IUIElementoConDescripcionSimple;
			if (iuielementoConDescripcionSimple == null)
			{
				return;
			}
			string text = string.Empty;
			IList<TextoLocalizadoAttribute> currentLocalizations = this.GetCurrentLocalizations<DescripcionLocalizadoAttribute>(atributes);
			if (currentLocalizations != null && currentLocalizations.Count > 0)
			{
				foreach (TextoLocalizadoAttribute textoLocalizadoAttribute in currentLocalizations)
				{
					DescripcionLocalizadoAttribute descripcionLocalizadoAttribute = (DescripcionLocalizadoAttribute)textoLocalizadoAttribute;
					if (!string.IsNullOrWhiteSpace(text))
					{
						text += "\n";
					}
					if (!string.IsNullOrWhiteSpace(descripcionLocalizadoAttribute.text))
					{
						text += descripcionLocalizadoAttribute.text;
					}
				}
			}
			if (extradata != null && member != null && modelOwner != null)
			{
				ValueTuple<Type, string> valueTuple = new ValueTuple<Type, string>(modelOwner.GetType(), member.Name);
				List<DescripcionDinamicaAttribute.DescripcionDinamicaHandler> list;
				if (extradata.paraType.descripcionesDinamicas.TryGetValue(valueTuple, out list))
				{
					foreach (DescripcionDinamicaAttribute.DescripcionDinamicaHandler descripcionDinamicaHandler in list)
					{
						if (descripcionDinamicaHandler != null)
						{
							if (!string.IsNullOrWhiteSpace(text))
							{
								text += "\n";
							}
							float num;
							string text2 = descripcionDinamicaHandler(out num, index);
							iuielementoConDescripcionSimple.widthMod = num;
							if (!string.IsNullOrWhiteSpace(text2))
							{
								text += text2;
							}
						}
					}
				}
			}
			if (!string.IsNullOrWhiteSpace(text))
			{
				iuielementoConDescripcionSimple.descripcion = text;
			}
		}

		// Token: 0x06000404 RID: 1028 RVA: 0x00010F68 File Offset: 0x0000F168
		private void SetValueAElementoDesdeModelo(IUIElementoConValor elemento, object modelo, bool silenced)
		{
			if (!elemento.isBinded)
			{
				throw new InvalidOperationException();
			}
			Type type = modelo.GetType();
			FieldInfo field = type.GetField(elemento.modelName, BindingFlags.Instance | BindingFlags.Public | BindingFlags.FlattenHierarchy);
			PropertyInfo property = type.GetProperty(elemento.modelName, BindingFlags.Instance | BindingFlags.Public | BindingFlags.FlattenHierarchy);
			bool flag;
			if (field != null)
			{
				flag = field.IsDefined(typeof(IgnoreValueAttribute));
			}
			else
			{
				flag = property != null && property.IsDefined(typeof(IgnoreValueAttribute));
			}
			if (flag)
			{
				return;
			}
			object obj;
			if (field != null)
			{
				obj = field.GetValue(modelo);
			}
			else
			{
				if (!(property != null))
				{
					return;
				}
				obj = property.GetValue(modelo);
			}
			if (obj == null)
			{
				return;
			}
			if (elemento.modelItemIndex > -1)
			{
				IList list;
				if (field != null)
				{
					list = field.GetValue(modelo) as IList;
				}
				else
				{
					if (!(property != null))
					{
						return;
					}
					list = property.GetValue(modelo) as IList;
				}
				if (list.ContieneIndexBase(elemento.modelItemIndex))
				{
					object obj2;
					try
					{
						obj2 = list[elemento.modelItemIndex];
					}
					catch (Exception)
					{
						throw;
					}
					elemento.SetValor(obj2, silenced);
					return;
				}
			}
			else
			{
				elemento.SetValor(obj, silenced);
			}
		}

		// Token: 0x06000405 RID: 1029 RVA: 0x00011094 File Offset: 0x0000F294
		private void SetValueAModeloDesdeElemento(object modelo, IUIElementoConValor elemento)
		{
			if (!elemento.isBinded)
			{
				throw new InvalidOperationException();
			}
			Type type = modelo.GetType();
			FieldInfo field = type.GetField(elemento.modelName, BindingFlags.Instance | BindingFlags.Public | BindingFlags.FlattenHierarchy);
			PropertyInfo property = type.GetProperty(elemento.modelName, BindingFlags.Instance | BindingFlags.Public | BindingFlags.FlattenHierarchy);
			bool flag;
			if (field != null)
			{
				flag = field.IsDefined(typeof(IgnoreValueAttribute));
			}
			else
			{
				flag = property != null && property.IsDefined(typeof(IgnoreValueAttribute));
			}
			if (flag)
			{
				return;
			}
			if (field == null && property == null)
			{
				return;
			}
			object valor = elemento.GetValor();
			if (valor == null)
			{
				return;
			}
			if (elemento.modelItemIndex > -1)
			{
				IList list;
				if (field != null)
				{
					list = field.GetValue(modelo) as IList;
				}
				else
				{
					if (!(property != null))
					{
						return;
					}
					list = property.GetValue(modelo) as IList;
				}
				list[elemento.modelItemIndex] = valor;
				return;
			}
			if (field != null)
			{
				field.SetValue(modelo, valor);
			}
			if (property != null)
			{
				property.SetValue(modelo, valor);
			}
		}

		// Token: 0x06000406 RID: 1030 RVA: 0x0001119C File Offset: 0x0000F39C
		private IEnumerator AsynDrawer(IUIPanel addTo, IEnumerable items, DynamicUIElementAttribute dina, MemberInfo memberInfo, object modelOwner, IEnumerable<Attribute> attr, DibujadorDynamico.ExtraData extradata)
		{
			bool ignorarValue = memberInfo.IsDefined(typeof(IgnoreValueAttribute));
			int index = -1;
			foreach (object obj in items)
			{
				int num = index;
				index = num + 1;
				IEnumerable<Attribute> enumerable = extradata.overrides.Concat(attr, modelOwner, memberInfo.Name, index);
				IUIElemento iuielemento = this.InstanciarUIElemento(dina, addTo, memberInfo, modelOwner, enumerable, extradata);
				string text = JsonUtility.ToJson(new ModeloConIndex
				{
					index = index,
					modeloName = memberInfo.Name
				});
				object obj2 = (ignorarValue ? null : obj);
				this.BindElemento(addTo, iuielemento, memberInfo, text, obj2, text, ignorarValue, true, enumerable);
				addTo.AddElementOnAsyncMode(text, iuielemento);
				if (index % 5 == 0)
				{
					yield return null;
					if (addTo.panel == null)
					{
						yield break;
					}
				}
			}
			IEnumerator enumerator = null;
			DibujadorDynamico.m_CoroutineDePedido.Remove(modelOwner);
			yield break;
			yield break;
		}

		// Token: 0x04000150 RID: 336
		private static DibujadorDynamico m_instance;

		// Token: 0x04000151 RID: 337
		private List<TextoLocalizadoAttribute> m_TempTEXTLOCAL = new List<TextoLocalizadoAttribute>();

		// Token: 0x04000152 RID: 338
		private List<TValleUILocalTextAttribute> m_TempTEXTLOCAL_Modding = new List<TValleUILocalTextAttribute>();

		// Token: 0x04000153 RID: 339
		private const string TodosKey = "TODOS*TODOS*TODOS";

		// Token: 0x04000154 RID: 340
		private static HashSet<IUIElemento> m_elementosTEMP = new HashSet<IUIElemento>();

		// Token: 0x04000155 RID: 341
		private static ConditionalWeakTable<object, Coroutine> m_CoroutineDePedido = new ConditionalWeakTable<object, Coroutine>();

		// Token: 0x02000173 RID: 371
		public class ExtraData
		{
			// Token: 0x04000490 RID: 1168
			public DibujadorDynamico.OverridesParaMienbros overrides = new DibujadorDynamico.OverridesParaMienbros();

			// Token: 0x04000491 RID: 1169
			public DibujadorDynamico.ExtraDataParaModel paraModel = new DibujadorDynamico.ExtraDataParaModel();

			// Token: 0x04000492 RID: 1170
			public DibujadorDynamico.ExtraDataParaType paraType = new DibujadorDynamico.ExtraDataParaType();

			// Token: 0x04000493 RID: 1171
			public HashSet<IUIElemento> todosLosDibujados = new HashSet<IUIElemento>();
		}

		// Token: 0x02000174 RID: 372
		public class OverridesParaMienbros
		{
			// Token: 0x06000AA3 RID: 2723 RVA: 0x00022E93 File Offset: 0x00021093
			public void AddTo(object model, string memberName, Attribute @override, int index = -1)
			{
				this.GetNotNull(model, memberName, index).attributes.Add(@override);
			}

			// Token: 0x06000AA4 RID: 2724 RVA: 0x00022EAC File Offset: 0x000210AC
			public IEnumerable<Attribute> Concat(IEnumerable<Attribute> original, Type modelType, string memberName, int index = -1)
			{
				ValueTuple<Type, string, int> valueTuple = new ValueTuple<Type, string, int>(modelType, memberName, index);
				DibujadorDynamico.OverridesParaMienbro overridesParaMienbro;
				if (this.overrides.TryGetValue(valueTuple, out overridesParaMienbro))
				{
					return original.Concat(overridesParaMienbro.attributes);
				}
				return original;
			}

			// Token: 0x06000AA5 RID: 2725 RVA: 0x00022EE4 File Offset: 0x000210E4
			public IEnumerable<Attribute> Concat(IEnumerable<Attribute> original, object model, string memberName, int index = -1)
			{
				Type type = model.GetType();
				return this.Concat(original, type, memberName, index);
			}

			// Token: 0x06000AA6 RID: 2726 RVA: 0x00022F04 File Offset: 0x00021104
			public DibujadorDynamico.OverridesParaMienbro GetNotNull(object model, string memberName, int index = -1)
			{
				Type type = model.GetType();
				return this.GetNotNull(type, memberName, index);
			}

			// Token: 0x06000AA7 RID: 2727 RVA: 0x00022F24 File Offset: 0x00021124
			public DibujadorDynamico.OverridesParaMienbro GetNotNull(Type modelType, string memberName, int index = -1)
			{
				ValueTuple<Type, string, int> valueTuple = new ValueTuple<Type, string, int>(modelType, memberName, index);
				DibujadorDynamico.OverridesParaMienbro overridesParaMienbro;
				if (!this.overrides.TryGetValue(valueTuple, out overridesParaMienbro))
				{
					overridesParaMienbro = new DibujadorDynamico.OverridesParaMienbro();
					this.overrides.Add(valueTuple, overridesParaMienbro);
				}
				return overridesParaMienbro;
			}

			// Token: 0x04000494 RID: 1172
			public Dictionary<ValueTuple<Type, string, int>, DibujadorDynamico.OverridesParaMienbro> overrides = new Dictionary<ValueTuple<Type, string, int>, DibujadorDynamico.OverridesParaMienbro>();
		}

		// Token: 0x02000175 RID: 373
		public class OverridesParaMienbro
		{
			// Token: 0x04000495 RID: 1173
			public List<Attribute> attributes = new List<Attribute>();
		}

		// Token: 0x02000176 RID: 374
		public class ExtraDataParaModel
		{
			// Token: 0x04000496 RID: 1174
			public HashSet<object> modelAdded = new HashSet<object>();

			// Token: 0x04000497 RID: 1175
			public Dictionary<ValueTuple<object, string>, List<Func<object>>> dataDelegates = new Dictionary<ValueTuple<object, string>, List<Func<object>>>();
		}

		// Token: 0x02000177 RID: 375
		public class ExtraDataParaType
		{
			// Token: 0x04000498 RID: 1176
			public List<MemberInfo> miembrosV2 = new List<MemberInfo>();

			// Token: 0x04000499 RID: 1177
			public Dictionary<ValueTuple<Type, string>, MemberInfo> miembrosDiccV2 = new Dictionary<ValueTuple<Type, string>, MemberInfo>();

			// Token: 0x0400049A RID: 1178
			public HashSet<Type> typesAdded = new HashSet<Type>();

			// Token: 0x0400049B RID: 1179
			public Dictionary<ValueTuple<Type, string>, List<Func<bool>>> activatedDelegates = new Dictionary<ValueTuple<Type, string>, List<Func<bool>>>();

			// Token: 0x0400049C RID: 1180
			public Dictionary<ValueTuple<Type, string>, ConfirmacionHandler> confirmables = new Dictionary<ValueTuple<Type, string>, ConfirmacionHandler>();

			// Token: 0x0400049D RID: 1181
			public Dictionary<ValueTuple<Type, string>, MethodInfo> secondaryActions = new Dictionary<ValueTuple<Type, string>, MethodInfo>();

			// Token: 0x0400049E RID: 1182
			public Dictionary<ValueTuple<Type, string>, MethodInfo> voidMethodInfo = new Dictionary<ValueTuple<Type, string>, MethodInfo>();

			// Token: 0x0400049F RID: 1183
			public Dictionary<ValueTuple<Type, string>, Func<bool>> ignoreIf = new Dictionary<ValueTuple<Type, string>, Func<bool>>();

			// Token: 0x040004A0 RID: 1184
			public Dictionary<ValueTuple<Type, string>, LabelDinamicoAttribute.LabelDinamicaHandler> labelDinamicos = new Dictionary<ValueTuple<Type, string>, LabelDinamicoAttribute.LabelDinamicaHandler>();

			// Token: 0x040004A1 RID: 1185
			public Dictionary<ValueTuple<Type, string>, List<DescripcionDinamicaAttribute.DescripcionDinamicaHandler>> descripcionesDinamicas = new Dictionary<ValueTuple<Type, string>, List<DescripcionDinamicaAttribute.DescripcionDinamicaHandler>>();

			// Token: 0x040004A2 RID: 1186
			public Dictionary<ValueTuple<Type, string>, Func<IUIPanel, IList<IUIElemento>>> selfDrawingListMetodo = new Dictionary<ValueTuple<Type, string>, Func<IUIPanel, IList<IUIElemento>>>();

			// Token: 0x040004A3 RID: 1187
			public Dictionary<ValueTuple<Type, string>, Func<IUIPanel, IUIElemento>> selfDrawingMetodo = new Dictionary<ValueTuple<Type, string>, Func<IUIPanel, IUIElemento>>();

			// Token: 0x040004A4 RID: 1188
			public HashSet<ValueTuple<Type, string>> selfDrawingSetConfigByDibujador = new HashSet<ValueTuple<Type, string>>();
		}

		// Token: 0x02000178 RID: 376
		public class ModelEstructura
		{
			// Token: 0x06000AAC RID: 2732 RVA: 0x00023048 File Offset: 0x00021248
			public void SetValue(object value)
			{
				FieldInfo fieldInfo = this.currentInfoInModel as FieldInfo;
				if (fieldInfo != null)
				{
					Type fieldType = fieldInfo.FieldType;
					if (fieldType != value.GetType())
					{
						value = Convert.ChangeType(value, fieldType);
					}
					fieldInfo.SetValue(this.modelParent, value);
					return;
				}
				PropertyInfo propertyInfo = this.currentInfoInModel as PropertyInfo;
				if (propertyInfo != null)
				{
					Type propertyType = propertyInfo.PropertyType;
					if (propertyType != value.GetType())
					{
						value = Convert.ChangeType(value, propertyType);
					}
					propertyInfo.SetValue(this.modelParent, value);
					return;
				}
				throw new ArgumentOutOfRangeException();
			}

			// Token: 0x06000AAD RID: 2733 RVA: 0x000230DC File Offset: 0x000212DC
			public object GetValue()
			{
				FieldInfo fieldInfo = this.currentInfoInModel as FieldInfo;
				if (fieldInfo != null)
				{
					return fieldInfo.GetValue(this.modelParent);
				}
				PropertyInfo propertyInfo = this.currentInfoInModel as PropertyInfo;
				if (propertyInfo != null)
				{
					return propertyInfo.GetValue(this.modelParent);
				}
				throw new ArgumentOutOfRangeException();
			}

			// Token: 0x040004A5 RID: 1189
			public object modelParent;

			// Token: 0x040004A6 RID: 1190
			public object modelCurrent;

			// Token: 0x040004A7 RID: 1191
			public int index = -1;

			// Token: 0x040004A8 RID: 1192
			public MemberInfo currentInfoInModel;

			// Token: 0x040004A9 RID: 1193
			public IEnumerable<Attribute> attributes;

			// Token: 0x040004AA RID: 1194
			public List<DibujadorDynamico.ModelEstructura> children = new List<DibujadorDynamico.ModelEstructura>();
		}
	}
}
