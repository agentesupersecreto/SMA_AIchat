using System;
using UnityEngine;

// Token: 0x02000004 RID: 4
public class ControllerGUI : MonoBehaviour
{
	// Token: 0x06000007 RID: 7 RVA: 0x00002574 File Offset: 0x00000774
	private void Start()
	{
		this.sceneMode = "eye";
		this.lodLevel0.gameObject.SetActive(true);
		this.lodLevel1.gameObject.SetActive(false);
		this.lodLevel2.gameObject.SetActive(false);
		if (this.sceneLightObject != null)
		{
			this.sceneLight = this.sceneLightObject.GetComponent<Light>();
		}
		if (this.targetObjectE != null)
		{
			this.targetRenderer = this.targetObjectE.transform.GetComponent<Renderer>();
			this.autoDilateObject = this.targetObjectE.gameObject.GetComponent<EyeAdv_AutoDilation>();
		}
		if (this.targetObjectE != null)
		{
			this.targetRenderer = this.targetObjectE.transform.GetComponent<Renderer>();
		}
		if (this.targetObjectF1 != null)
		{
			this.targetRenderer1 = this.targetObjectF1.transform.GetComponent<Renderer>();
		}
		if (this.targetObjectF2 != null)
		{
			this.targetRenderer2 = this.targetObjectF2.transform.GetComponent<Renderer>();
		}
	}

	// Token: 0x06000008 RID: 8 RVA: 0x00002684 File Offset: 0x00000884
	private void Update()
	{
		this.lightIntensity = Mathf.Clamp(this.lightIntensity, 0f, 1f);
		this.lightDirection = Mathf.Clamp(this.lightDirection, 0f, 1f);
		this.sceneLightObject.transform.eulerAngles = new Vector3(this.sceneLightObject.transform.eulerAngles.x, Mathf.Lerp(0f, 359f, this.lightDirection), this.sceneLightObject.transform.eulerAngles.z);
		this.sceneLight.intensity = this.lightIntensity;
		if (this.autoDilateObject != null)
		{
			this.autoDilateObject.enableAutoDilation = this.autoDilate;
		}
		this.irisSize = Mathf.Clamp(this.irisSize, 0f, 1f);
		this.parallaxAmt = Mathf.Clamp(this.parallaxAmt, 0f, 1f);
		this.scleraSize = Mathf.Clamp(this.scleraSize, 0f, 1f);
		this.irisTextureF = (float)Mathf.Clamp(Mathf.FloorToInt(this.irisTextureF), 0, this.irisTextures.Length - 1);
		this.irisTextureD = this.irisTextureF / (float)(this.irisTextures.Length - 1);
		this.irisTexture = Mathf.Clamp(Mathf.FloorToInt(this.irisTextureF), 0, this.irisTextures.Length - 1);
		if (this.targetRenderer != null)
		{
			this.targetRenderer.material.SetFloat("_irisSize", Mathf.Lerp(1.5f, 5f, this.irisSize));
			this.targetRenderer.material.SetFloat("_parallax", Mathf.Lerp(0f, 0.05f, this.parallaxAmt));
			if (!this.autoDilate)
			{
				this.targetRenderer.material.SetFloat("_pupilSize", this.pupilDilation);
			}
			this.targetRenderer.material.SetFloat("_scleraSize", Mathf.Lerp(1.1f, 2.2f, this.scleraSize));
			this.targetRenderer.material.SetColor("_irisColor", this.irisColor);
			this.targetRenderer.material.SetColor("_scleraColor", this.scleraColor);
			this.targetRenderer.material.SetTexture("_IrisColorTex", this.irisTextures[this.irisTexture]);
		}
		if (this.targetRenderer1 != null)
		{
			this.targetRenderer1.material.CopyPropertiesFromMaterial(this.targetRenderer.material);
		}
		if (this.targetRenderer2 != null)
		{
			this.targetRenderer2.material.CopyPropertiesFromMaterial(this.targetRenderer.material);
		}
		if (this.currentLodLevel != this.lodLevel)
		{
			this.doLodSwitch = -1f;
			if (this.lodLevel < 0.31f && this.currentLodLevel > 0.31f)
			{
				this.doLodSwitch = 0f;
			}
			if (this.lodLevel > 0.7f && this.currentLodLevel > 0.7f)
			{
				this.doLodSwitch = 2f;
			}
			if (this.lodLevel > 0.31f && this.lodLevel < 0.7f && (this.currentLodLevel < 0.31f || this.currentLodLevel > 0.7f))
			{
				this.doLodSwitch = 1f;
			}
			this.currentLodLevel = this.lodLevel;
			if (this.doLodSwitch >= 0f)
			{
				if (this.doLodSwitch == 0f && this.lodLevel0 != null)
				{
					this.lodLevel0.gameObject.SetActive(true);
					this.lodLevel1.gameObject.SetActive(false);
					this.lodLevel2.gameObject.SetActive(false);
					this.targetObjectF1 = this.lodLevel0;
				}
				if (this.doLodSwitch == 1f && this.lodLevel1 != null)
				{
					this.lodLevel0.gameObject.SetActive(false);
					this.lodLevel1.gameObject.SetActive(true);
					this.lodLevel2.gameObject.SetActive(false);
					this.targetObjectF1 = this.lodLevel1;
				}
				if (this.doLodSwitch == 2f && this.lodLevel2 != null)
				{
					this.lodLevel0.gameObject.SetActive(false);
					this.lodLevel1.gameObject.SetActive(false);
					this.lodLevel2.gameObject.SetActive(true);
					this.targetObjectF1 = this.lodLevel2;
				}
			}
		}
	}

	// Token: 0x06000009 RID: 9 RVA: 0x00002B24 File Offset: 0x00000D24
	private void OnGUI()
	{
		GUI.color = new Color(1f, 1f, 1f, 1f);
		if (this.texTitle != null)
		{
			GUI.Label(new Rect(25f, 25f, (float)this.texTitle.width, (float)this.texTitle.height), this.texTitle);
		}
		if (this.texTD != null)
		{
			GUI.Label(new Rect(800f, 45f, (float)(this.texTD.width * 2), (float)(this.texTD.height * 2)), this.texTD);
		}
		GUI.color = new Color(1f, 1f, 1f, 1f);
		if (this.texDiv1 != null)
		{
			GUI.Label(new Rect(150f, 130f, (float)this.texDiv1.width, (float)this.texDiv1.height), this.texDiv1);
		}
		GUI.color = this.colorGold;
		GUI.Label(new Rect(35f, 128f, 180f, 20f), "EYEBALL VIEW");
		GUI.color = this.colorGrey;
		GUI.Label(new Rect(160f, 128f, 280f, 20f), "CHARACTER VIEW (not included)");
		if (Event.current.type == EventType.MouseUp && new Rect(35f, 128f, 100f, 20f).Contains(Event.current.mousePosition))
		{
			this.sceneMode = "eye";
		}
		if (Event.current.type == EventType.MouseUp && new Rect(160f, 128f, 100f, 20f).Contains(Event.current.mousePosition))
		{
			this.sceneMode = "figure";
		}
		this.GenerateSlider("EYE LOD LEVEL", 35, 185, false, "lodLevel", 293);
		GUI.color = new Color(1f, 1f, 1f, 1f);
		if (this.texDiv1 != null)
		{
			GUI.Label(new Rect(130f, 217f, (float)this.texDiv1.width, (float)this.texDiv1.height), this.texDiv1);
		}
		if (this.texDiv1 != null)
		{
			GUI.Label(new Rect(240f, 217f, (float)this.texDiv1.width, (float)this.texDiv1.height), this.texDiv1);
		}
		GUI.color = this.colorGold;
		if (this.lodLevel > 0.32f)
		{
			GUI.color = this.colorGrey;
		}
		if (new Rect(60f, 215f, 40f, 20f).Contains(Event.current.mousePosition))
		{
			GUI.color = this.colorHighlight;
		}
		GUI.Label(new Rect(60f, 215f, 40f, 20f), "LOD 0");
		if (Event.current.type == EventType.MouseUp && new Rect(60f, 215f, 100f, 20f).Contains(Event.current.mousePosition))
		{
			this.lodLevel = 0f;
		}
		GUI.color = this.colorGold;
		if (this.lodLevel < 0.32f || this.lodLevel > 0.7f)
		{
			GUI.color = this.colorGrey;
		}
		if (new Rect(165f, 215f, 50f, 20f).Contains(Event.current.mousePosition))
		{
			GUI.color = this.colorHighlight;
		}
		GUI.Label(new Rect(165f, 215f, 50f, 20f), "LOD 1");
		if (Event.current.type == EventType.MouseUp && new Rect(165f, 215f, 100f, 20f).Contains(Event.current.mousePosition))
		{
			this.lodLevel = 0.5f;
		}
		GUI.color = this.colorGold;
		if (this.lodLevel < 0.7f)
		{
			GUI.color = this.colorGrey;
		}
		if (new Rect(270f, 215f, 50f, 20f).Contains(Event.current.mousePosition))
		{
			GUI.color = this.colorHighlight;
		}
		GUI.Label(new Rect(270f, 215f, 50f, 20f), "LOD 2");
		if (Event.current.type == EventType.MouseUp && new Rect(270f, 215f, 100f, 20f).Contains(Event.current.mousePosition))
		{
			this.lodLevel = 1f;
		}
		this.GenerateSlider("PUPIL DILATION", 35, 248, true, "pupilDilation", 293);
		GUI.color = new Color(1f, 1f, 1f, 1f);
		if (this.texDiv1 != null)
		{
			GUI.Label(new Rect(272f, 280f, (float)this.texDiv1.width, (float)this.texDiv1.height), this.texDiv1);
		}
		GUI.color = this.colorGold;
		if (!this.autoDilate)
		{
			GUI.color = this.colorGrey;
		}
		if (new Rect(240f, 278f, 40f, 20f).Contains(Event.current.mousePosition))
		{
			GUI.color = this.colorHighlight;
		}
		GUI.Label(new Rect(240f, 278f, 40f, 20f), "auto");
		GUI.color = this.colorGold;
		if (this.autoDilate)
		{
			GUI.color = this.colorGrey;
		}
		if (new Rect(280f, 278f, 40f, 20f).Contains(Event.current.mousePosition))
		{
			GUI.color = this.colorHighlight;
		}
		GUI.Label(new Rect(280f, 278f, 50f, 20f), "manual");
		if (Event.current.type == EventType.MouseUp && new Rect(240f, 278f, 40f, 20f).Contains(Event.current.mousePosition))
		{
			this.autoDilate = true;
		}
		if (Event.current.type == EventType.MouseUp && new Rect(280f, 278f, 50f, 20f).Contains(Event.current.mousePosition))
		{
			this.autoDilate = false;
		}
		this.GenerateSlider("SCLERA SIZE", 35, 310, true, "scleraSize", 293);
		this.GenerateSlider("IRIS SIZE", 35, 350, true, "irisSize", 293);
		this.GenerateSlider("IRIS TEXTURE", 35, 390, false, "irisTexture", 293);
		GUI.color = new Color(1f, 1f, 1f, 1f);
		for (int i = 0; i < this.irisTextures.Length; i++)
		{
			if (this.texDiv1 != null)
			{
				GUI.Label(new Rect((float)(36 + i * 22), 416f, (float)this.texDiv1.width, (float)this.texDiv1.height), this.texDiv1);
			}
		}
		this.GenerateSlider("IRIS PARALLAX", 35, 440, true, "irisParallax", 293);
		GUI.color = this.colorGold;
		GUI.Label(new Rect(35f, 510f, 180f, 20f), "IRIS COLOR");
		GUI.color = this.colorGrey;
		GUI.Label(new Rect(35f, 525f, 20f, 20f), "r");
		GUI.Label(new Rect(35f, 538f, 20f, 20f), "g");
		GUI.Label(new Rect(35f, 551f, 20f, 20f), "b");
		GUI.Label(new Rect(35f, 564f, 20f, 20f), "a");
		this.GenerateSlider("", 50, 512, false, "irisColorR", 278);
		this.GenerateSlider("", 50, 525, false, "irisColorG", 278);
		this.GenerateSlider("", 50, 538, false, "irisColorB", 278);
		this.GenerateSlider("", 50, 550, false, "irisColorA", 278);
		GUI.color = this.colorGold;
		GUI.Label(new Rect(35f, 590f, 180f, 20f), "SCLERA COLOR");
		GUI.color = this.colorGrey;
		GUI.Label(new Rect(35f, 605f, 20f, 20f), "r");
		GUI.Label(new Rect(35f, 618f, 20f, 20f), "g");
		GUI.Label(new Rect(35f, 631f, 20f, 20f), "b");
		GUI.Label(new Rect(35f, 644f, 20f, 20f), "a");
		this.GenerateSlider("", 50, 592, false, "scleraColorR", 278);
		this.GenerateSlider("", 50, 605, false, "scleraColorG", 278);
		this.GenerateSlider("", 50, 618, false, "scleraColorB", 278);
		this.GenerateSlider("", 50, 630, false, "scleraColorA", 278);
		GUI.color = this.colorGold;
		GUI.Label(new Rect(35f, 730f, 150f, 20f), "LIGHT DIRECTION");
		this.GenerateSlider("", 160, 716, false, "lightDir", 820);
	}

	// Token: 0x0600000A RID: 10 RVA: 0x000035C0 File Offset: 0x000017C0
	private void GenerateSlider(string title, int sX, int sY, bool showPercent, string funcName, int sWidth)
	{
		GUI.color = this.colorGold;
		if (title != "")
		{
			GUI.Label(new Rect((float)sX, (float)sY, 180f, 20f), title);
		}
		if (funcName == "lightDir" && showPercent)
		{
			GUI.Label(new Rect((float)(sX + (sWidth - 28)), (float)sY, 80f, 20f), Mathf.CeilToInt(this.lightDirection * 100f).ToString() + "%");
		}
		if (funcName == "lodLevel" && showPercent)
		{
			GUI.Label(new Rect((float)(sX + (sWidth - 28)), (float)sY, 80f, 20f), Mathf.CeilToInt(100f - this.lodLevel * 100f).ToString() + "%");
		}
		if (funcName == "pupilDilation" && showPercent)
		{
			GUI.Label(new Rect((float)(sX + (sWidth - 28)), (float)sY, 80f, 20f), Mathf.CeilToInt(this.pupilDilation * 100f).ToString() + "%");
		}
		if (funcName == "scleraSize" && showPercent)
		{
			GUI.Label(new Rect((float)(sX + (sWidth - 28)), (float)sY, 80f, 20f), Mathf.CeilToInt(this.scleraSize * 100f).ToString() + "%");
		}
		if (funcName == "irisSize" && showPercent)
		{
			GUI.Label(new Rect((float)(sX + (sWidth - 28)), (float)sY, 80f, 20f), Mathf.CeilToInt(this.irisSize * 100f).ToString() + "%");
		}
		if (funcName == "irisTexture" && showPercent)
		{
			GUI.Label(new Rect((float)(sX + (sWidth - 28)), (float)sY, 80f, 20f), Mathf.CeilToInt(this.irisTextureD * 100f).ToString() + "%");
		}
		if (funcName == "irisParallax" && showPercent)
		{
			GUI.Label(new Rect((float)(sX + (sWidth - 28)), (float)sY, 80f, 20f), Mathf.CeilToInt(this.parallaxAmt * 100f).ToString() + "%");
		}
		if (funcName == "irisColorR" && showPercent)
		{
			GUI.Label(new Rect((float)(sX + (sWidth - 28)), (float)sY, 80f, 20f), Mathf.CeilToInt(this.irisColor.r * 100f).ToString() + "%");
		}
		if (funcName == "irisColorG" && showPercent)
		{
			GUI.Label(new Rect((float)(sX + (sWidth - 28)), (float)sY, 80f, 20f), Mathf.CeilToInt(this.irisColor.g * 100f).ToString() + "%");
		}
		if (funcName == "irisColorB" && showPercent)
		{
			GUI.Label(new Rect((float)(sX + (sWidth - 28)), (float)sY, 80f, 20f), Mathf.CeilToInt(this.irisColor.b * 100f).ToString() + "%");
		}
		if (funcName == "irisColorA" && showPercent)
		{
			GUI.Label(new Rect((float)(sX + (sWidth - 28)), (float)sY, 80f, 20f), Mathf.CeilToInt(this.irisColor.a * 100f).ToString() + "%");
		}
		if (funcName == "scleraColorR" && showPercent)
		{
			GUI.Label(new Rect((float)(sX + (sWidth - 28)), (float)sY, 80f, 20f), Mathf.CeilToInt(this.scleraColor.r * 100f).ToString() + "%");
		}
		if (funcName == "scleraColorG" && showPercent)
		{
			GUI.Label(new Rect((float)(sX + (sWidth - 28)), (float)sY, 80f, 20f), Mathf.CeilToInt(this.scleraColor.g * 100f).ToString() + "%");
		}
		if (funcName == "scleraColorB" && showPercent)
		{
			GUI.Label(new Rect((float)(sX + (sWidth - 28)), (float)sY, 80f, 20f), Mathf.CeilToInt(this.scleraColor.b * 100f).ToString() + "%");
		}
		if (funcName == "scleraColorA" && showPercent)
		{
			GUI.Label(new Rect((float)(sX + (sWidth - 28)), (float)sY, 80f, 20f), Mathf.CeilToInt(this.scleraColor.a * 100f).ToString() + "%");
		}
		GUI.color = new Color(1f, 1f, 1f, 1f);
		if (this.texSlideB != null)
		{
			GUI.DrawTextureWithTexCoords(new Rect((float)sX, (float)(sY + 22), (float)(sWidth + 2), 7f), this.texSlideB, new Rect((float)sX, (float)(sY + 22), (float)(sWidth + 2), 7f), true);
		}
		if (funcName == "lightDir" && this.texSlideA != null)
		{
			GUI.DrawTextureWithTexCoords(new Rect((float)(sX + 1), (float)(sY + 23), Mathf.Lerp(1f, (float)sWidth, this.lightDirection), 5f), this.texSlideA, new Rect((float)(sX + 1), (float)(sY + 23), (float)sWidth, 5f), true);
		}
		if (funcName == "lodLevel" && this.texSlideA != null)
		{
			GUI.DrawTextureWithTexCoords(new Rect((float)(sX + 1), (float)(sY + 23), Mathf.Lerp(1f, (float)sWidth, this.lodLevel), 5f), this.texSlideA, new Rect((float)(sX + 1), (float)(sY + 23), (float)sWidth, 5f), true);
		}
		if (funcName == "pupilDilation" && this.texSlideA != null)
		{
			GUI.DrawTextureWithTexCoords(new Rect((float)(sX + 1), (float)(sY + 23), Mathf.Lerp(1f, (float)sWidth, this.pupilDilation), 5f), this.texSlideA, new Rect((float)(sX + 1), (float)(sY + 23), (float)sWidth, 5f), true);
		}
		if (funcName == "scleraSize" && this.texSlideA != null)
		{
			GUI.DrawTextureWithTexCoords(new Rect((float)(sX + 1), (float)(sY + 23), Mathf.Lerp(1f, (float)sWidth, this.scleraSize), 5f), this.texSlideA, new Rect((float)(sX + 1), (float)(sY + 23), (float)sWidth, 5f), true);
		}
		if (funcName == "irisSize" && this.texSlideA != null)
		{
			GUI.DrawTextureWithTexCoords(new Rect((float)(sX + 1), (float)(sY + 23), Mathf.Lerp(1f, (float)sWidth, this.irisSize), 5f), this.texSlideA, new Rect((float)(sX + 1), (float)(sY + 23), (float)sWidth, 5f), true);
		}
		if (funcName == "irisTexture" && this.texSlideA != null)
		{
			GUI.DrawTextureWithTexCoords(new Rect((float)(sX + 1), (float)(sY + 23), Mathf.Lerp(1f, (float)sWidth, this.irisTextureD), 5f), this.texSlideA, new Rect((float)(sX + 1), (float)(sY + 23), (float)sWidth, 5f), true);
		}
		if (funcName == "irisParallax" && this.texSlideA != null)
		{
			GUI.DrawTextureWithTexCoords(new Rect((float)(sX + 1), (float)(sY + 23), Mathf.Lerp(1f, (float)sWidth, this.parallaxAmt), 5f), this.texSlideA, new Rect((float)(sX + 1), (float)(sY + 23), (float)sWidth, 5f), true);
		}
		GUI.color = new Color(this.irisColor.r, this.irisColor.g, this.irisColor.b, this.irisColor.a);
		if (funcName == "irisColorR" && this.texSlideD != null)
		{
			GUI.DrawTextureWithTexCoords(new Rect((float)(sX + 1), (float)(sY + 23), Mathf.Lerp(1f, (float)sWidth, this.irisColor.r), 5f), this.texSlideD, new Rect((float)(sX + 1), (float)(sY + 23), (float)sWidth, 5f), true);
		}
		if (funcName == "irisColorG" && this.texSlideD != null)
		{
			GUI.DrawTextureWithTexCoords(new Rect((float)(sX + 1), (float)(sY + 23), Mathf.Lerp(1f, (float)sWidth, this.irisColor.g), 5f), this.texSlideD, new Rect((float)(sX + 1), (float)(sY + 23), (float)sWidth, 5f), true);
		}
		if (funcName == "irisColorB" && this.texSlideD != null)
		{
			GUI.DrawTextureWithTexCoords(new Rect((float)(sX + 1), (float)(sY + 23), Mathf.Lerp(1f, (float)sWidth, this.irisColor.b), 5f), this.texSlideD, new Rect((float)(sX + 1), (float)(sY + 23), (float)sWidth, 5f), true);
		}
		GUI.color = this.colorGrey * 2f;
		if (funcName == "irisColorA" && this.texSlideD != null)
		{
			GUI.DrawTextureWithTexCoords(new Rect((float)(sX + 1), (float)(sY + 23), Mathf.Lerp(1f, (float)sWidth, this.irisColor.a), 5f), this.texSlideD, new Rect((float)(sX + 1), (float)(sY + 23), (float)sWidth, 5f), true);
		}
		GUI.color = new Color(this.scleraColor.r, this.scleraColor.g, this.scleraColor.b, this.scleraColor.a);
		if (funcName == "scleraColorR" && this.texSlideD != null)
		{
			GUI.DrawTextureWithTexCoords(new Rect((float)(sX + 1), (float)(sY + 23), Mathf.Lerp(1f, (float)sWidth, this.scleraColor.r), 5f), this.texSlideD, new Rect((float)(sX + 1), (float)(sY + 23), (float)sWidth, 5f), true);
		}
		if (funcName == "scleraColorG" && this.texSlideD != null)
		{
			GUI.DrawTextureWithTexCoords(new Rect((float)(sX + 1), (float)(sY + 23), Mathf.Lerp(1f, (float)sWidth, this.scleraColor.g), 5f), this.texSlideD, new Rect((float)(sX + 1), (float)(sY + 23), (float)sWidth, 5f), true);
		}
		if (funcName == "scleraColorB" && this.texSlideD != null)
		{
			GUI.DrawTextureWithTexCoords(new Rect((float)(sX + 1), (float)(sY + 23), Mathf.Lerp(1f, (float)sWidth, this.scleraColor.b), 5f), this.texSlideD, new Rect((float)(sX + 1), (float)(sY + 23), (float)sWidth, 5f), true);
		}
		GUI.color = this.colorGrey * 2f;
		if (funcName == "scleraColorA" && this.texSlideD != null)
		{
			GUI.DrawTextureWithTexCoords(new Rect((float)(sX + 1), (float)(sY + 23), Mathf.Lerp(1f, (float)sWidth, this.scleraColor.a), 5f), this.texSlideD, new Rect((float)(sX + 1), (float)(sY + 23), (float)sWidth, 5f), true);
		}
		GUI.color = new Color(1f, 1f, 1f, 0f);
		if (funcName == "lightDir")
		{
			this.lightDirection = GUI.HorizontalSlider(new Rect((float)(sX - 4), (float)(sY + 19), (float)(sWidth + 17), 10f), this.lightDirection, 0f, 1f);
		}
		if (funcName == "lodLevel")
		{
			this.lodLevel = GUI.HorizontalSlider(new Rect((float)(sX - 4), (float)(sY + 19), (float)(sWidth + 17), 10f), this.lodLevel, 0f, 1f);
		}
		if (funcName == "pupilDilation")
		{
			this.pupilDilation = GUI.HorizontalSlider(new Rect((float)(sX - 4), (float)(sY + 19), (float)(sWidth + 17), 10f), this.pupilDilation, 0f, 1f);
		}
		if (funcName == "scleraSize")
		{
			this.scleraSize = GUI.HorizontalSlider(new Rect((float)(sX - 4), (float)(sY + 19), (float)(sWidth + 17), 10f), this.scleraSize, 0f, 1f);
		}
		if (funcName == "irisSize")
		{
			this.irisSize = GUI.HorizontalSlider(new Rect((float)(sX - 4), (float)(sY + 19), (float)(sWidth + 17), 10f), this.irisSize, 0f, 1f);
		}
		if (funcName == "irisTexture")
		{
			this.irisTextureF = GUI.HorizontalSlider(new Rect((float)(sX - 4), (float)(sY + 19), (float)(sWidth + 17), 10f), this.irisTextureF, 0f, (float)this.irisTextures.Length - 1f);
		}
		if (funcName == "irisParallax")
		{
			this.parallaxAmt = GUI.HorizontalSlider(new Rect((float)(sX - 4), (float)(sY + 19), (float)(sWidth + 17), 10f), this.parallaxAmt, 0f, 1f);
		}
		if (funcName == "irisColorR")
		{
			this.irisColor.r = GUI.HorizontalSlider(new Rect((float)(sX - 4), (float)(sY + 19), (float)(sWidth + 17), 10f), this.irisColor.r, 0f, 1f);
		}
		if (funcName == "irisColorG")
		{
			this.irisColor.g = GUI.HorizontalSlider(new Rect((float)(sX - 4), (float)(sY + 19), (float)(sWidth + 17), 10f), this.irisColor.g, 0f, 1f);
		}
		if (funcName == "irisColorB")
		{
			this.irisColor.b = GUI.HorizontalSlider(new Rect((float)(sX - 4), (float)(sY + 19), (float)(sWidth + 17), 10f), this.irisColor.b, 0f, 1f);
		}
		if (funcName == "irisColorA")
		{
			this.irisColor.a = GUI.HorizontalSlider(new Rect((float)(sX - 4), (float)(sY + 19), (float)(sWidth + 17), 10f), this.irisColor.a, 0f, 1f);
		}
		if (funcName == "scleraColorR")
		{
			this.scleraColor.r = GUI.HorizontalSlider(new Rect((float)(sX - 4), (float)(sY + 19), (float)(sWidth + 17), 10f), this.scleraColor.r, 0f, 1f);
		}
		if (funcName == "scleraColorG")
		{
			this.scleraColor.g = GUI.HorizontalSlider(new Rect((float)(sX - 4), (float)(sY + 19), (float)(sWidth + 17), 10f), this.scleraColor.g, 0f, 1f);
		}
		if (funcName == "scleraColorB")
		{
			this.scleraColor.b = GUI.HorizontalSlider(new Rect((float)(sX - 4), (float)(sY + 19), (float)(sWidth + 17), 10f), this.scleraColor.b, 0f, 1f);
		}
		if (funcName == "scleraColorA")
		{
			this.scleraColor.a = GUI.HorizontalSlider(new Rect((float)(sX - 4), (float)(sY + 19), (float)(sWidth + 17), 10f), this.scleraColor.a, 0f, 1f);
		}
	}

	// Token: 0x0400001E RID: 30
	public Transform sceneLightObject;

	// Token: 0x0400001F RID: 31
	public float lightDirection = 0.25f;

	// Token: 0x04000020 RID: 32
	public float lightIntensity = 0.75f;

	// Token: 0x04000021 RID: 33
	public GameObject modeObjectE;

	// Token: 0x04000022 RID: 34
	public GameObject modeObjectF;

	// Token: 0x04000023 RID: 35
	public Transform targetObjectE;

	// Token: 0x04000024 RID: 36
	public Transform targetObjectF1;

	// Token: 0x04000025 RID: 37
	public Transform targetObjectF2;

	// Token: 0x04000026 RID: 38
	public bool autoDilate;

	// Token: 0x04000027 RID: 39
	public float lodLevel = 0.15f;

	// Token: 0x04000028 RID: 40
	public float parallaxAmt = 1f;

	// Token: 0x04000029 RID: 41
	public float pupilDilation = 0.5f;

	// Token: 0x0400002A RID: 42
	public float scleraSize;

	// Token: 0x0400002B RID: 43
	public float irisSize = 0.22f;

	// Token: 0x0400002C RID: 44
	public Color irisColor = new Color(1f, 1f, 1f, 1f);

	// Token: 0x0400002D RID: 45
	public Color scleraColor = new Color(1f, 1f, 1f, 1f);

	// Token: 0x0400002E RID: 46
	public int irisTexture;

	// Token: 0x0400002F RID: 47
	public Texture[] irisTextures;

	// Token: 0x04000030 RID: 48
	public Texture2D texTitle;

	// Token: 0x04000031 RID: 49
	public Texture2D texTD;

	// Token: 0x04000032 RID: 50
	public Texture2D texDiv1;

	// Token: 0x04000033 RID: 51
	public Texture2D texSlideA;

	// Token: 0x04000034 RID: 52
	public Texture2D texSlideB;

	// Token: 0x04000035 RID: 53
	public Texture2D texSlideD;

	// Token: 0x04000036 RID: 54
	public Transform lodLevel0;

	// Token: 0x04000037 RID: 55
	public Transform lodLevel1;

	// Token: 0x04000038 RID: 56
	public Transform lodLevel2;

	// Token: 0x04000039 RID: 57
	[HideInInspector]
	public string sceneMode = "figure";

	// Token: 0x0400003A RID: 58
	private float currentLodLevel;

	// Token: 0x0400003B RID: 59
	private float doLodSwitch = -1f;

	// Token: 0x0400003C RID: 60
	private Vector3 lodRot;

	// Token: 0x0400003D RID: 61
	private Light sceneLight;

	// Token: 0x0400003E RID: 62
	private Renderer targetRenderer;

	// Token: 0x0400003F RID: 63
	private Renderer targetRenderer1;

	// Token: 0x04000040 RID: 64
	private Renderer targetRenderer2;

	// Token: 0x04000041 RID: 65
	private float lightAngle;

	// Token: 0x04000042 RID: 66
	private float ambientFac;

	// Token: 0x04000043 RID: 67
	private float irisTextureF;

	// Token: 0x04000044 RID: 68
	private float irisTextureD;

	// Token: 0x04000045 RID: 69
	private Color colorGold = new Color(0.79f, 0.55f, 0.054f, 1f);

	// Token: 0x04000046 RID: 70
	private Color colorGrey = new Color(0.333f, 0.3f, 0.278f, 1f);

	// Token: 0x04000047 RID: 71
	private Color colorHighlight = new Color(0.99f, 0.75f, 0.074f, 1f);

	// Token: 0x04000048 RID: 72
	private EyeAdv_AutoDilation autoDilateObject;
}
