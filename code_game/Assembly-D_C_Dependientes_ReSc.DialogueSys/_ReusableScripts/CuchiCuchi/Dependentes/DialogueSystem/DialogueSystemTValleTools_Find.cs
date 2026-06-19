using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using PixelCrushers.DialogueSystem;
using UnityEngine;

namespace Assets._ReusableScripts.CuchiCuchi.Dependentes.DialogueSystem
{
	// Token: 0x02000016 RID: 22
	public class DialogueSystemTValleTools_Find : AplicableCustomMonobehaviour
	{
		// Token: 0x060000C8 RID: 200 RVA: 0x0000452C File Offset: 0x0000272C
		public void Find(string ToFind, string ReplaceWith, bool replace, bool buscarSoloUnaPalabra, StringBuilder hitsToPrint = null)
		{
			if (string.IsNullOrWhiteSpace(ToFind))
			{
				return;
			}
			RegexOptions regexOptions = (this.ignoreCase ? RegexOptions.IgnoreCase : RegexOptions.None);
			string text;
			if (buscarSoloUnaPalabra)
			{
				text = "(?i)\\b" + Regex.Escape(ToFind) + "\\b";
			}
			else
			{
				text = Regex.Escape(ToFind);
			}
			Dictionary<DialogueEntry, Conversation> conversationDeEntry = new Dictionary<DialogueEntry, Conversation>();
			Dictionary<DialogueEntry, string> titleDeEntry = new Dictionary<DialogueEntry, string>();
			List<DialogueEntry> entrys = new List<DialogueEntry>();
			Dictionary<Field, DialogueEntry> entryTheField = new Dictionary<Field, DialogueEntry>();
			HashSet<ValueTuple<Conversation, DialogueEntry, string, string>> hashSet = new HashSet<ValueTuple<Conversation, DialogueEntry, string, string>>();
			if (!this.buscarEnTodasLasConversaciones)
			{
				string[] array = this.conversations;
				Action<DialogueEntry> <>9__1;
				Action<DialogueEntry> <>9__2;
				for (int i = 0; i < array.Length; i++)
				{
					string text2 = array[i];
					Conversation conver2 = this.dialogueDatabase.GetConversation(text2);
					conver2.dialogueEntries.ForEach(delegate(DialogueEntry e)
					{
						conversationDeEntry.Add(e, conver2);
					});
					List<DialogueEntry> dialogueEntries = conver2.dialogueEntries;
					Action<DialogueEntry> action;
					if ((action = <>9__1) == null)
					{
						action = (<>9__1 = delegate(DialogueEntry e)
						{
							Dictionary<DialogueEntry, string> titleDeEntry2 = titleDeEntry;
							string text15;
							if (!e.isGroup)
							{
								text15 = e.fields.FirstOrDefault((Field f) => f.title == "Dialogue Text").value;
							}
							else
							{
								text15 = e.fields.FirstOrDefault((Field f) => f.title == "Title").value;
							}
							titleDeEntry2.Add(e, text15);
						});
					}
					dialogueEntries.ForEach(action);
					List<DialogueEntry> dialogueEntries2 = conver2.dialogueEntries;
					Action<DialogueEntry> action2;
					if ((action2 = <>9__2) == null)
					{
						action2 = (<>9__2 = delegate(DialogueEntry e)
						{
							entrys.Add(e);
						});
					}
					dialogueEntries2.ForEach(action2);
				}
			}
			else
			{
				using (List<Conversation>.Enumerator enumerator = this.dialogueDatabase.conversations.GetEnumerator())
				{
					Action<DialogueEntry> <>9__6;
					Action<DialogueEntry> <>9__7;
					while (enumerator.MoveNext())
					{
						Conversation conver = enumerator.Current;
						conver.dialogueEntries.ForEach(delegate(DialogueEntry e)
						{
							conversationDeEntry.Add(e, conver);
						});
						List<DialogueEntry> dialogueEntries3 = conver.dialogueEntries;
						Action<DialogueEntry> action3;
						if ((action3 = <>9__6) == null)
						{
							action3 = (<>9__6 = delegate(DialogueEntry e)
							{
								titleDeEntry.Add(e, e.fields.FirstOrDefault((Field f) => f.title == "Title").value);
							});
						}
						dialogueEntries3.ForEach(action3);
						List<DialogueEntry> dialogueEntries4 = conver.dialogueEntries;
						Action<DialogueEntry> action4;
						if ((action4 = <>9__7) == null)
						{
							action4 = (<>9__7 = delegate(DialogueEntry e)
							{
								entrys.Add(e);
							});
						}
						dialogueEntries4.ForEach(action4);
					}
				}
			}
			using (List<DialogueEntry>.Enumerator enumerator2 = entrys.GetEnumerator())
			{
				while (enumerator2.MoveNext())
				{
					DialogueEntry entry = enumerator2.Current;
					entry.fields.ForEach(delegate(Field f)
					{
						entryTheField.Add(f, entry);
					});
					foreach (Field field in entry.fields)
					{
						if (this.ignoreCase)
						{
							if (!string.IsNullOrEmpty(field.value) && Regex.IsMatch(field.value, text, regexOptions))
							{
								hashSet.Add(new ValueTuple<Conversation, DialogueEntry, string, string>(conversationDeEntry[entry], entry, field.title, field.value));
							}
						}
						else if (!string.IsNullOrEmpty(field.value) && Regex.IsMatch(field.value, text, regexOptions))
						{
							hashSet.Add(new ValueTuple<Conversation, DialogueEntry, string, string>(conversationDeEntry[entry], entry, field.title, field.value));
						}
					}
					if (this.ignoreCase)
					{
						DialogueEntry entry5 = entry;
						if (((entry5 != null) ? entry5.conditionsString : null) != null && Regex.IsMatch(entry.conditionsString, text, regexOptions))
						{
							hashSet.Add(new ValueTuple<Conversation, DialogueEntry, string, string>(conversationDeEntry[entry], entry, "conditionsString", entry.conditionsString));
						}
						DialogueEntry entry2 = entry;
						if (((entry2 != null) ? entry2.userScript : null) != null && Regex.IsMatch(entry.userScript, text, regexOptions))
						{
							hashSet.Add(new ValueTuple<Conversation, DialogueEntry, string, string>(conversationDeEntry[entry], entry, "userScript", entry.userScript));
						}
					}
					else
					{
						DialogueEntry entry3 = entry;
						if (((entry3 != null) ? entry3.conditionsString : null) != null && Regex.IsMatch(entry.conditionsString, text, regexOptions))
						{
							hashSet.Add(new ValueTuple<Conversation, DialogueEntry, string, string>(conversationDeEntry[entry], entry, "conditionsString", entry.conditionsString));
						}
						DialogueEntry entry4 = entry;
						if (((entry4 != null) ? entry4.userScript : null) != null && Regex.IsMatch(entry.userScript, text, regexOptions))
						{
							hashSet.Add(new ValueTuple<Conversation, DialogueEntry, string, string>(conversationDeEntry[entry], entry, "userScript", entry.userScript));
						}
					}
				}
			}
			if (hashSet.Count == 0)
			{
				Debug.Log("None were found");
				return;
			}
			if (hitsToPrint != null)
			{
				foreach (ValueTuple<Conversation, DialogueEntry, string, string> valueTuple in hashSet)
				{
					hitsToPrint.Append(valueTuple.Item4);
					hitsToPrint.Append("\n");
				}
			}
			foreach (ValueTuple<Conversation, DialogueEntry, string, string> valueTuple2 in hashSet)
			{
				DialogueEntry item = valueTuple2.Item2;
				string text3 = titleDeEntry[item];
				Conversation item2 = valueTuple2.Item1;
				Debug.Log(string.Concat(new string[]
				{
					item2.Title,
					"->[",
					item.id.ToString(),
					"]",
					text3,
					"->",
					valueTuple2.Item3,
					" data:\n",
					valueTuple2.Item4
				}));
			}
			if (replace)
			{
				MatchEvaluator <>9__10;
				MatchEvaluator <>9__11;
				MatchEvaluator <>9__12;
				MatchEvaluator <>9__13;
				MatchEvaluator <>9__14;
				foreach (ValueTuple<Conversation, DialogueEntry, string, string> valueTuple3 in hashSet)
				{
					DialogueEntry item3 = valueTuple3.Item2;
					string text4 = titleDeEntry[item3];
					if (this.replaceMenuOrDialogue)
					{
						string menuText = item3.MenuText;
						DialogueEntry dialogueEntry = item3;
						string text5 = menuText;
						string text6 = text;
						MatchEvaluator matchEvaluator;
						if ((matchEvaluator = <>9__10) == null)
						{
							matchEvaluator = (<>9__10 = (Match m) => this.ApplyCase(m.Value, ReplaceWith));
						}
						dialogueEntry.MenuText = Regex.Replace(text5, text6, matchEvaluator, regexOptions);
						Debug.Log(menuText + "-> " + item3.MenuText);
						string dialogueText = item3.DialogueText;
						DialogueEntry dialogueEntry2 = item3;
						string text7 = dialogueText;
						string text8 = text;
						MatchEvaluator matchEvaluator2;
						if ((matchEvaluator2 = <>9__11) == null)
						{
							matchEvaluator2 = (<>9__11 = (Match m) => this.ApplyCase(m.Value, ReplaceWith));
						}
						dialogueEntry2.DialogueText = Regex.Replace(text7, text8, matchEvaluator2, regexOptions);
						Debug.Log(dialogueText + "-> " + item3.DialogueText);
					}
					if (this.replaceSequence)
					{
						string sequence = item3.Sequence;
						DialogueEntry dialogueEntry3 = item3;
						string text9 = sequence;
						string text10 = text;
						MatchEvaluator matchEvaluator3;
						if ((matchEvaluator3 = <>9__12) == null)
						{
							matchEvaluator3 = (<>9__12 = (Match m) => this.ApplyCase(m.Value, ReplaceWith));
						}
						dialogueEntry3.Sequence = Regex.Replace(text9, text10, matchEvaluator3, regexOptions);
						Debug.Log(sequence + "-> " + item3.Sequence);
					}
					if (this.replaceConditionOrScript)
					{
						string conditionsString = item3.conditionsString;
						DialogueEntry dialogueEntry4 = item3;
						string text11 = conditionsString;
						string text12 = text;
						MatchEvaluator matchEvaluator4;
						if ((matchEvaluator4 = <>9__13) == null)
						{
							matchEvaluator4 = (<>9__13 = (Match m) => this.ApplyCase(m.Value, ReplaceWith));
						}
						dialogueEntry4.conditionsString = Regex.Replace(text11, text12, matchEvaluator4, regexOptions);
						Debug.Log(conditionsString + "-> " + item3.conditionsString);
						string userScript = item3.userScript;
						DialogueEntry dialogueEntry5 = item3;
						string text13 = userScript;
						string text14 = text;
						MatchEvaluator matchEvaluator5;
						if ((matchEvaluator5 = <>9__14) == null)
						{
							matchEvaluator5 = (<>9__14 = (Match m) => this.ApplyCase(m.Value, ReplaceWith));
						}
						dialogueEntry5.userScript = Regex.Replace(text13, text14, matchEvaluator5, regexOptions);
						Debug.Log(userScript + "-> " + item3.userScript);
					}
				}
			}
		}

		// Token: 0x060000C9 RID: 201 RVA: 0x00004E70 File Offset: 0x00003070
		private string ApplyCase(string original, string replacement)
		{
			if (string.IsNullOrEmpty(original))
			{
				return replacement;
			}
			if (original == original.ToLower())
			{
				return replacement.ToLower();
			}
			if (original == original.ToUpper())
			{
				return replacement.ToUpper();
			}
			if (char.IsUpper(original[0]))
			{
				return char.ToUpper(replacement[0]).ToString() + replacement.Substring(1);
			}
			return replacement;
		}

		// Token: 0x060000CA RID: 202 RVA: 0x00004EE1 File Offset: 0x000030E1
		protected override CustomMonobehaviourBotonConfig Boton1()
		{
			return new CustomMonobehaviourBotonConfig
			{
				text = "Find"
			};
		}

		// Token: 0x060000CB RID: 203 RVA: 0x00004EF3 File Offset: 0x000030F3
		protected override void OnAplicar()
		{
			this.Find(this.toFind, this.replaceWith, false, false, null);
		}

		// Token: 0x060000CC RID: 204 RVA: 0x00004F0A File Offset: 0x0000310A
		protected override CustomMonobehaviourBotonConfig Boton2()
		{
			return new CustomMonobehaviourBotonConfig
			{
				text = "Find Una Sola Palabra"
			};
		}

		// Token: 0x060000CD RID: 205 RVA: 0x00004F1C File Offset: 0x0000311C
		protected override void OnAplicar2()
		{
			StringBuilder stringBuilder = new StringBuilder();
			this.Find(this.toFind, this.replaceWith, false, true, stringBuilder);
			HandleTextFile.WriteTextFile("DEBUG_PRINT/EncontradosEnDialogos.txt", stringBuilder.ToString());
		}

		// Token: 0x060000CE RID: 206 RVA: 0x00004F54 File Offset: 0x00003154
		protected override CustomMonobehaviourBotonConfig Boton3()
		{
			return new CustomMonobehaviourBotonConfig
			{
				text = "Find And Replace",
				confirmar = true
			};
		}

		// Token: 0x060000CF RID: 207 RVA: 0x00004F6D File Offset: 0x0000316D
		protected override void OnAplicar3()
		{
			this.Find(this.toFind, this.replaceWith, true, false, null);
		}

		// Token: 0x060000D0 RID: 208 RVA: 0x00004F84 File Offset: 0x00003184
		protected override CustomMonobehaviourBotonConfig Boton4()
		{
			return new CustomMonobehaviourBotonConfig
			{
				text = "Find And Replace (Multiples)",
				confirmar = true
			};
		}

		// Token: 0x060000D1 RID: 209 RVA: 0x00004FA0 File Offset: 0x000031A0
		protected override void OnAplicar4()
		{
			string[] array = this.toFind.Split(new string[] { "\r\n", "\r", "\n" }, StringSplitOptions.RemoveEmptyEntries);
			string[] array2 = this.replaceWith.Split(new string[] { "\r\n", "\r", "\n" }, StringSplitOptions.RemoveEmptyEntries);
			if (array.Length != array2.Length)
			{
				Debug.LogError("no se pudo");
				return;
			}
			for (int i = 0; i < array.Length; i++)
			{
				string text = array[i];
				string text2 = array2[i];
				this.Find(char.ToUpper(text[0]).ToString() + text.Substring(1), char.ToUpper(text2[0]).ToString() + text2.Substring(1), true, true, null);
			}
		}

		// Token: 0x04000050 RID: 80
		public DialogueDatabase dialogueDatabase;

		// Token: 0x04000051 RID: 81
		[ConversationPopup(false)]
		public string[] conversations;

		// Token: 0x04000052 RID: 82
		public bool buscarEnTodasLasConversaciones;

		// Token: 0x04000053 RID: 83
		public bool ignoreCase;

		// Token: 0x04000054 RID: 84
		[TextArea]
		public string toFind;

		// Token: 0x04000055 RID: 85
		[Space]
		[TextArea]
		public string replaceWith;

		// Token: 0x04000056 RID: 86
		public bool replaceMenuOrDialogue;

		// Token: 0x04000057 RID: 87
		public bool replaceSequence;

		// Token: 0x04000058 RID: 88
		public bool replaceConditionOrScript;
	}
}
