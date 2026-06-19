using System;
using System.Collections.Generic;
using UnityEngine;

namespace Assets._ReusableScripts.CuchiCuchi.Controllers
{
	// Token: 0x02000249 RID: 585
	public static class AnimatorParamsDicc
	{
		// Token: 0x170002E4 RID: 740
		// (get) Token: 0x06000D16 RID: 3350 RVA: 0x0003C2EA File Offset: 0x0003A4EA
		public static int bocaEmoHash
		{
			get
			{
				if (AnimatorParamsDicc.m_bocaEmoHash == null)
				{
					AnimatorParamsDicc.m_bocaEmoHash = new int?(Animator.StringToHash("FACE_Boca_Emo_w"));
				}
				return AnimatorParamsDicc.m_bocaEmoHash.Value;
			}
		}

		// Token: 0x170002E5 RID: 741
		// (get) Token: 0x06000D17 RID: 3351 RVA: 0x0003C316 File Offset: 0x0003A516
		public static int bocaDiscursoHash
		{
			get
			{
				if (AnimatorParamsDicc.m_bocaDiscursoHash == null)
				{
					AnimatorParamsDicc.m_bocaDiscursoHash = new int?(Animator.StringToHash("FACE_Boca_discurso_w"));
				}
				return AnimatorParamsDicc.m_bocaDiscursoHash.Value;
			}
		}

		// Token: 0x170002E6 RID: 742
		// (get) Token: 0x06000D18 RID: 3352 RVA: 0x0003C342 File Offset: 0x0003A542
		public static int faceXHash
		{
			get
			{
				if (AnimatorParamsDicc.m_faceXHash == null)
				{
					AnimatorParamsDicc.m_faceXHash = new int?(Animator.StringToHash("FACE_cara_x"));
				}
				return AnimatorParamsDicc.m_faceXHash.Value;
			}
		}

		// Token: 0x170002E7 RID: 743
		// (get) Token: 0x06000D19 RID: 3353 RVA: 0x0003C36E File Offset: 0x0003A56E
		public static int faceYHash
		{
			get
			{
				if (AnimatorParamsDicc.m_faceYHash == null)
				{
					AnimatorParamsDicc.m_faceYHash = new int?(Animator.StringToHash("FACE_cara_y"));
				}
				return AnimatorParamsDicc.m_faceYHash.Value;
			}
		}

		// Token: 0x170002E8 RID: 744
		// (get) Token: 0x06000D1A RID: 3354 RVA: 0x0003C39A File Offset: 0x0003A59A
		public static int bocaXHash
		{
			get
			{
				if (AnimatorParamsDicc.m_bocaXHash == null)
				{
					AnimatorParamsDicc.m_bocaXHash = new int?(Animator.StringToHash("FACE_Boca_x"));
				}
				return AnimatorParamsDicc.m_bocaXHash.Value;
			}
		}

		// Token: 0x170002E9 RID: 745
		// (get) Token: 0x06000D1B RID: 3355 RVA: 0x0003C3C6 File Offset: 0x0003A5C6
		public static int bocaYHash
		{
			get
			{
				if (AnimatorParamsDicc.m_bocaYHash == null)
				{
					AnimatorParamsDicc.m_bocaYHash = new int?(Animator.StringToHash("FACE_Boca_y"));
				}
				return AnimatorParamsDicc.m_bocaYHash.Value;
			}
		}

		// Token: 0x170002EA RID: 746
		// (get) Token: 0x06000D1C RID: 3356 RVA: 0x0003C3F4 File Offset: 0x0003A5F4
		public static Dictionary<int, int> tipoToHash
		{
			get
			{
				if (AnimatorParamsDicc.m_tipoToHash == null)
				{
					AnimatorParamsDicc.m_tipoToHash = new Dictionary<int, int>
					{
						{
							0,
							Animator.StringToHash("FACE_Alegria")
						},
						{
							1,
							Animator.StringToHash("FACE_Placer")
						},
						{
							2,
							Animator.StringToHash("FACE_Dolor")
						},
						{
							3,
							Animator.StringToHash("FACE_Rabia")
						},
						{
							4,
							Animator.StringToHash("FACE_Sorpresa")
						},
						{
							5,
							Animator.StringToHash("FACE_Aburrimiento")
						},
						{
							6,
							Animator.StringToHash("FACE_Fear")
						}
					};
				}
				return AnimatorParamsDicc.m_tipoToHash;
			}
		}

		// Token: 0x06000D1D RID: 3357 RVA: 0x0003C494 File Offset: 0x0003A694
		public static int Hash(this ControlladorDeGestosFacialesEmocionales.TipoDeExpresion tipo)
		{
			int num;
			try
			{
				num = AnimatorParamsDicc.tipoToHash[(int)tipo];
			}
			catch (Exception ex)
			{
				Debug.LogWarning("Exception ahead");
				throw ex;
			}
			return num;
		}

		// Token: 0x04000AF3 RID: 2803
		private const string alegria = "FACE_Alegria";

		// Token: 0x04000AF4 RID: 2804
		private const string placer = "FACE_Placer";

		// Token: 0x04000AF5 RID: 2805
		private const string dolor = "FACE_Dolor";

		// Token: 0x04000AF6 RID: 2806
		private const string rabia = "FACE_Rabia";

		// Token: 0x04000AF7 RID: 2807
		private const string miedo = "FACE_Fear";

		// Token: 0x04000AF8 RID: 2808
		private const string sorpresa = "FACE_Sorpresa";

		// Token: 0x04000AF9 RID: 2809
		private const string aburrimiento = "FACE_Aburrimiento";

		// Token: 0x04000AFA RID: 2810
		private const string bocaW = "FACE_Boca_Emo_w";

		// Token: 0x04000AFB RID: 2811
		private const string bocaDiscurso = "FACE_Boca_discurso_w";

		// Token: 0x04000AFC RID: 2812
		private const string faceX = "FACE_cara_x";

		// Token: 0x04000AFD RID: 2813
		private const string faceY = "FACE_cara_y";

		// Token: 0x04000AFE RID: 2814
		private const string bocaX = "FACE_Boca_x";

		// Token: 0x04000AFF RID: 2815
		private const string bocaY = "FACE_Boca_y";

		// Token: 0x04000B00 RID: 2816
		private static int? m_bocaEmoHash;

		// Token: 0x04000B01 RID: 2817
		private static int? m_bocaDiscursoHash;

		// Token: 0x04000B02 RID: 2818
		private static int? m_faceXHash;

		// Token: 0x04000B03 RID: 2819
		private static int? m_faceYHash;

		// Token: 0x04000B04 RID: 2820
		private static int? m_bocaXHash;

		// Token: 0x04000B05 RID: 2821
		private static int? m_bocaYHash;

		// Token: 0x04000B06 RID: 2822
		private static Dictionary<int, int> m_tipoToHash;
	}
}
