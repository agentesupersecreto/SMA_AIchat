using System;

namespace Assets.TValle.BeachGirl.Genetica.Alteradores.Runtime.Interpretadores
{
	// Token: 0x0200004B RID: 75
	public static class Interpretacion
	{
		// Token: 0x02000083 RID: 131
		public enum CantidadContable
		{
			// Token: 0x04000278 RID: 632
			[LabelLocalizado("too few", "US")]
			tooFew = -2,
			// Token: 0x04000279 RID: 633
			[LabelLocalizado("few", "US")]
			few,
			// Token: 0x0400027A RID: 634
			[LabelLocalizado("normal", "US")]
			normal,
			// Token: 0x0400027B RID: 635
			[LabelLocalizado("many", "US")]
			many,
			// Token: 0x0400027C RID: 636
			[LabelLocalizado("too many", "US")]
			tooMany
		}

		// Token: 0x02000084 RID: 132
		public enum CantidadNoContable
		{
			// Token: 0x0400027E RID: 638
			[LabelLocalizado("very little", "US")]
			veryLittle = -2,
			// Token: 0x0400027F RID: 639
			[LabelLocalizado("little", "US")]
			little,
			// Token: 0x04000280 RID: 640
			[LabelLocalizado("some", "US")]
			some,
			// Token: 0x04000281 RID: 641
			[LabelLocalizado("a lot", "US")]
			aLot,
			// Token: 0x04000282 RID: 642
			[LabelLocalizado("too much", "US")]
			tooMuch
		}

		// Token: 0x02000085 RID: 133
		public enum Capacidad
		{
			// Token: 0x04000284 RID: 644
			[LabelLocalizado("very low", "US")]
			veryLow = -2,
			// Token: 0x04000285 RID: 645
			[LabelLocalizado("low", "US")]
			low,
			// Token: 0x04000286 RID: 646
			[LabelLocalizado("medium", "US")]
			medium,
			// Token: 0x04000287 RID: 647
			[LabelLocalizado("high", "US")]
			high,
			// Token: 0x04000288 RID: 648
			[LabelLocalizado("very high", "US")]
			veryHigh
		}

		// Token: 0x02000086 RID: 134
		public enum AngleDirection
		{
			// Token: 0x0400028A RID: 650
			[LabelLocalizado("very downwards", "US")]
			veryDownwards = -2,
			// Token: 0x0400028B RID: 651
			[LabelLocalizado("downwards", "US")]
			downwards,
			// Token: 0x0400028C RID: 652
			[LabelLocalizado("medium", "US")]
			medium,
			// Token: 0x0400028D RID: 653
			[LabelLocalizado("upwards", "US")]
			upwards,
			// Token: 0x0400028E RID: 654
			[LabelLocalizado("very upwards", "US")]
			veryUpwards
		}

		// Token: 0x02000087 RID: 135
		public enum Tono
		{
			// Token: 0x04000290 RID: 656
			[LabelLocalizado("very dark", "US")]
			veryDark = -2,
			// Token: 0x04000291 RID: 657
			[LabelLocalizado("dark", "US")]
			dark,
			// Token: 0x04000292 RID: 658
			[LabelLocalizado("normal", "US")]
			normal,
			// Token: 0x04000293 RID: 659
			[LabelLocalizado("light", "US")]
			light,
			// Token: 0x04000294 RID: 660
			[LabelLocalizado("very light", "US")]
			veryLight
		}

		// Token: 0x02000088 RID: 136
		public enum Size
		{
			// Token: 0x04000296 RID: 662
			[LabelLocalizado("very small", "US")]
			verySmall = -2,
			// Token: 0x04000297 RID: 663
			[LabelLocalizado("small", "US")]
			small,
			// Token: 0x04000298 RID: 664
			[LabelLocalizado("normal", "US")]
			normal,
			// Token: 0x04000299 RID: 665
			[LabelLocalizado("large", "US")]
			large,
			// Token: 0x0400029A RID: 666
			[LabelLocalizado("very large", "US")]
			veryLarge
		}

		// Token: 0x02000089 RID: 137
		public enum Tightness
		{
			// Token: 0x0400029C RID: 668
			[LabelLocalizado("very loose", "US")]
			veryLoose = -2,
			// Token: 0x0400029D RID: 669
			[LabelLocalizado("loose", "US")]
			loose,
			// Token: 0x0400029E RID: 670
			[LabelLocalizado("normal", "US")]
			normal,
			// Token: 0x0400029F RID: 671
			[LabelLocalizado("tight", "US")]
			tight,
			// Token: 0x040002A0 RID: 672
			[LabelLocalizado("very tight", "US")]
			veryTight
		}

		// Token: 0x0200008A RID: 138
		public enum Depth
		{
			// Token: 0x040002A2 RID: 674
			[LabelLocalizado("very shallow", "US")]
			veryShallow = -2,
			// Token: 0x040002A3 RID: 675
			[LabelLocalizado("shallow", "US")]
			shallow,
			// Token: 0x040002A4 RID: 676
			[LabelLocalizado("normal", "US")]
			normal,
			// Token: 0x040002A5 RID: 677
			[LabelLocalizado("deep", "US")]
			deep,
			// Token: 0x040002A6 RID: 678
			[LabelLocalizado("very deep", "US")]
			veryDeep
		}

		// Token: 0x0200008B RID: 139
		public enum HoleDepth
		{
			// Token: 0x040002A8 RID: 680
			[LabelLocalizado("very narrow", "US")]
			veryNarrow = -2,
			// Token: 0x040002A9 RID: 681
			[LabelLocalizado("narrow", "US")]
			narrow,
			// Token: 0x040002AA RID: 682
			[LabelLocalizado("normal", "US")]
			normal,
			// Token: 0x040002AB RID: 683
			[LabelLocalizado("deep", "US")]
			deep,
			// Token: 0x040002AC RID: 684
			[LabelLocalizado("very deep", "US")]
			veryDeep
		}

		// Token: 0x0200008C RID: 140
		public enum Height
		{
			// Token: 0x040002AE RID: 686
			[LabelLocalizado("very short", "US")]
			veryShort = -2,
			// Token: 0x040002AF RID: 687
			[LabelLocalizado("short", "US")]
			@short,
			// Token: 0x040002B0 RID: 688
			[LabelLocalizado("normal", "US")]
			normal,
			// Token: 0x040002B1 RID: 689
			[LabelLocalizado("tall", "US")]
			tall,
			// Token: 0x040002B2 RID: 690
			[LabelLocalizado("very tall", "US")]
			veryTall
		}

		// Token: 0x0200008D RID: 141
		public enum Thickness
		{
			// Token: 0x040002B4 RID: 692
			[LabelLocalizado("very narrow", "US")]
			veryNarrow = -2,
			// Token: 0x040002B5 RID: 693
			[LabelLocalizado("narrow", "US")]
			narrow,
			// Token: 0x040002B6 RID: 694
			[LabelLocalizado("normal", "US")]
			normal,
			// Token: 0x040002B7 RID: 695
			[LabelLocalizado("thick", "US")]
			thick,
			// Token: 0x040002B8 RID: 696
			[LabelLocalizado("very thick", "US")]
			veryThick
		}

		// Token: 0x0200008E RID: 142
		public enum Length
		{
			// Token: 0x040002BA RID: 698
			[LabelLocalizado("very short", "US")]
			veryShort = -2,
			// Token: 0x040002BB RID: 699
			[LabelLocalizado("short", "US")]
			@short,
			// Token: 0x040002BC RID: 700
			[LabelLocalizado("normal", "US")]
			normal,
			// Token: 0x040002BD RID: 701
			[LabelLocalizado("long", "US")]
			@long,
			// Token: 0x040002BE RID: 702
			[LabelLocalizado("very long", "US")]
			veryLong
		}

		// Token: 0x0200008F RID: 143
		public enum Distance
		{
			// Token: 0x040002C0 RID: 704
			[LabelLocalizado("very close. ", "US")]
			veryClose = -2,
			// Token: 0x040002C1 RID: 705
			[LabelLocalizado("close", "US")]
			close,
			// Token: 0x040002C2 RID: 706
			[LabelLocalizado("normal", "US")]
			normal,
			// Token: 0x040002C3 RID: 707
			[LabelLocalizado("distant", "US")]
			distant,
			// Token: 0x040002C4 RID: 708
			[LabelLocalizado("far distant", "US")]
			veryDistant
		}

		// Token: 0x02000090 RID: 144
		public enum Opening
		{
			// Token: 0x040002C6 RID: 710
			[LabelLocalizado("very closed", "US")]
			veryClosed = -2,
			// Token: 0x040002C7 RID: 711
			[LabelLocalizado("closed", "US")]
			closed,
			// Token: 0x040002C8 RID: 712
			[LabelLocalizado("normal", "US")]
			normal,
			// Token: 0x040002C9 RID: 713
			[LabelLocalizado("open", "US")]
			open,
			// Token: 0x040002CA RID: 714
			[LabelLocalizado("very open", "US")]
			veryOpen
		}

		// Token: 0x02000091 RID: 145
		public enum Clarity
		{
			// Token: 0x040002CC RID: 716
			[LabelLocalizado("very dark", "US")]
			veryDark = -2,
			// Token: 0x040002CD RID: 717
			[LabelLocalizado("dark", "US")]
			dark,
			// Token: 0x040002CE RID: 718
			[LabelLocalizado("normal", "US")]
			normal,
			// Token: 0x040002CF RID: 719
			[LabelLocalizado("light", "US")]
			light,
			// Token: 0x040002D0 RID: 720
			[LabelLocalizado("very light", "US")]
			veryLight
		}

		// Token: 0x02000092 RID: 146
		public enum Amplitude
		{
			// Token: 0x040002D2 RID: 722
			[LabelLocalizado("very thin", "US")]
			veryThin = -2,
			// Token: 0x040002D3 RID: 723
			[LabelLocalizado("thin", "US")]
			thin,
			// Token: 0x040002D4 RID: 724
			[LabelLocalizado("normal", "US")]
			normal,
			// Token: 0x040002D5 RID: 725
			[LabelLocalizado("wide", "US")]
			wide,
			// Token: 0x040002D6 RID: 726
			[LabelLocalizado("very wide", "US")]
			veryWide
		}

		// Token: 0x02000093 RID: 147
		public enum SkinTone
		{
			// Token: 0x040002D8 RID: 728
			[LabelLocalizado("Light Pale", "US")]
			lightPale,
			// Token: 0x040002D9 RID: 729
			[LabelLocalizado("Pale", "US")]
			pale,
			// Token: 0x040002DA RID: 730
			[LabelLocalizado("Olive", "US")]
			olive,
			// Token: 0x040002DB RID: 731
			[LabelLocalizado("Reddish", "US")]
			reddish,
			// Token: 0x040002DC RID: 732
			[LabelLocalizado("Pale Dark", "US")]
			paleDark,
			// Token: 0x040002DD RID: 733
			[LabelLocalizado("Brown", "US")]
			brown,
			// Token: 0x040002DE RID: 734
			[LabelLocalizado("Dark Reddish", "US")]
			darkReddish,
			// Token: 0x040002DF RID: 735
			[LabelLocalizado("Light Black", "US")]
			lightBlack,
			// Token: 0x040002E0 RID: 736
			[LabelLocalizado("Black", "US")]
			black
		}

		// Token: 0x02000094 RID: 148
		public enum BodyType
		{
			// Token: 0x040002E2 RID: 738
			[LabelLocalizado("normal", "US")]
			normal,
			// Token: 0x040002E3 RID: 739
			[LabelLocalizado("slender", "US")]
			slender,
			// Token: 0x040002E4 RID: 740
			[LabelLocalizado("curvy", "US")]
			curvy,
			// Token: 0x040002E5 RID: 741
			[LabelLocalizado("chubby", "US")]
			chubby,
			// Token: 0x040002E6 RID: 742
			[LabelLocalizado("fat", "US")]
			fat,
			// Token: 0x040002E7 RID: 743
			[LabelLocalizado("athletic", "US")]
			athletic,
			// Token: 0x040002E8 RID: 744
			[LabelLocalizado("voluptuous", "US")]
			voluptuous,
			// Token: 0x040002E9 RID: 745
			[LabelLocalizado("pear", "US")]
			pear,
			// Token: 0x040002EA RID: 746
			[LabelLocalizado("milker", "US")]
			milker,
			// Token: 0x040002EB RID: 747
			[LabelLocalizado("milky Pear", "US")]
			milkyPear,
			// Token: 0x040002EC RID: 748
			[LabelLocalizado("strong", "US")]
			strong
		}

		// Token: 0x02000095 RID: 149
		[Obsolete]
		public enum FaceType
		{
			// Token: 0x040002EE RID: 750
			[LabelLocalizado("oval", "US")]
			oval,
			// Token: 0x040002EF RID: 751
			[LabelLocalizado("square", "US")]
			square,
			// Token: 0x040002F0 RID: 752
			[LabelLocalizado("round", "US")]
			round,
			// Token: 0x040002F1 RID: 753
			[LabelLocalizado("pear", "US")]
			pear,
			// Token: 0x040002F2 RID: 754
			[LabelLocalizado("oblong", "US")]
			oblong,
			// Token: 0x040002F3 RID: 755
			[LabelLocalizado("rectangle", "US")]
			rectangle,
			// Token: 0x040002F4 RID: 756
			[LabelLocalizado("triangle", "US")]
			triangle,
			// Token: 0x040002F5 RID: 757
			[LabelLocalizado("diamond", "US")]
			diamond,
			// Token: 0x040002F6 RID: 758
			[LabelLocalizado("heart", "US")]
			heart
		}

		// Token: 0x02000096 RID: 150
		public enum FaceTypeV2
		{
			// Token: 0x040002F8 RID: 760
			[LabelLocalizado("caucasian", "US")]
			caucasian,
			// Token: 0x040002F9 RID: 761
			[LabelLocalizado("african", "US")]
			afreican,
			// Token: 0x040002FA RID: 762
			[LabelLocalizado("asian", "US")]
			asian,
			// Token: 0x040002FB RID: 763
			[LabelLocalizado("latina", "US")]
			latina,
			// Token: 0x040002FC RID: 764
			[LabelLocalizado("cartoonish", "US")]
			toon
		}

		// Token: 0x02000097 RID: 151
		public enum PersonalidadType
		{
			// Token: 0x040002FE RID: 766
			[LabelLocalizado("respectful", "US")]
			respectful,
			// Token: 0x040002FF RID: 767
			[LabelLocalizado("perverted", "US")]
			perverted,
			// Token: 0x04000300 RID: 768
			[LabelLocalizado("shy", "US")]
			shy,
			// Token: 0x04000301 RID: 769
			[LabelLocalizado("rude", "US")]
			rude,
			// Token: 0x04000302 RID: 770
			[LabelLocalizado("outgoing", "US")]
			extroverted,
			// Token: 0x04000303 RID: 771
			[LabelLocalizado("avarage", "US")]
			none = 99
		}
	}
}
