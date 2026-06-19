using System;
using System.Collections;
using System.Collections.Generic;
using com.ootii.Actors.AnimationControllers;
using com.ootii.Actors.Attributes;
using com.ootii.Actors.Combat;
using com.ootii.Data.Serializers;
using com.ootii.Helpers;
using com.ootii.Messages;
using com.ootii.Reactors;
using UnityEngine;

namespace com.ootii.Actors.LifeCores
{
	// Token: 0x0200009E RID: 158
	public class ActorCore : MonoBehaviour, IActorCore, ILifeCore, IActorStateSource, IDamageable
	{
		// Token: 0x17000259 RID: 601
		// (get) Token: 0x060008C7 RID: 2247 RVA: 0x0002EDE6 File Offset: 0x0002CFE6
		// (set) Token: 0x060008C8 RID: 2248 RVA: 0x0002EDEE File Offset: 0x0002CFEE
		public GameObject AttributeSourceOwner
		{
			get
			{
				return this._AttributeSourceOwner;
			}
			set
			{
				this._AttributeSourceOwner = value;
			}
		}

		// Token: 0x1700025A RID: 602
		// (get) Token: 0x060008C9 RID: 2249 RVA: 0x0002EDF7 File Offset: 0x0002CFF7
		// (set) Token: 0x060008CA RID: 2250 RVA: 0x0002EDFF File Offset: 0x0002CFFF
		public IAttributeSource AttributeSource
		{
			get
			{
				return this.mAttributeSource;
			}
			set
			{
				this.mAttributeSource = value;
			}
		}

		// Token: 0x1700025B RID: 603
		// (get) Token: 0x060008CB RID: 2251 RVA: 0x0002EE08 File Offset: 0x0002D008
		public Transform Transform
		{
			get
			{
				return base.gameObject.transform;
			}
		}

		// Token: 0x1700025C RID: 604
		// (get) Token: 0x060008CC RID: 2252 RVA: 0x0002EE15 File Offset: 0x0002D015
		// (set) Token: 0x060008CD RID: 2253 RVA: 0x0002EE1D File Offset: 0x0002D01D
		public virtual bool IsAlive
		{
			get
			{
				return this._IsAlive;
			}
			set
			{
				this._IsAlive = value;
			}
		}

		// Token: 0x1700025D RID: 605
		// (get) Token: 0x060008CE RID: 2254 RVA: 0x0002EE26 File Offset: 0x0002D026
		// (set) Token: 0x060008CF RID: 2255 RVA: 0x0002EE2E File Offset: 0x0002D02E
		public string HealthID
		{
			get
			{
				return this._HealthID;
			}
			set
			{
				this._HealthID = value;
			}
		}

		// Token: 0x1700025E RID: 606
		// (get) Token: 0x060008D0 RID: 2256 RVA: 0x0002EE37 File Offset: 0x0002D037
		// (set) Token: 0x060008D1 RID: 2257 RVA: 0x0002EE3F File Offset: 0x0002D03F
		public string DamagedMotion
		{
			get
			{
				return this._DamagedMotion;
			}
			set
			{
				this._DamagedMotion = value;
			}
		}

		// Token: 0x1700025F RID: 607
		// (get) Token: 0x060008D2 RID: 2258 RVA: 0x0002EE48 File Offset: 0x0002D048
		// (set) Token: 0x060008D3 RID: 2259 RVA: 0x0002EE50 File Offset: 0x0002D050
		public string DeathMotion
		{
			get
			{
				return this._DeathMotion;
			}
			set
			{
				this._DeathMotion = value;
			}
		}

		// Token: 0x17000260 RID: 608
		// (get) Token: 0x060008D4 RID: 2260 RVA: 0x0002EE59 File Offset: 0x0002D059
		// (set) Token: 0x060008D5 RID: 2261 RVA: 0x0002EE61 File Offset: 0x0002D061
		public List<ActorCoreState> States
		{
			get
			{
				return this._States;
			}
			set
			{
				this._States = value;
			}
		}

		// Token: 0x17000261 RID: 609
		// (get) Token: 0x060008D6 RID: 2262 RVA: 0x0002EE6A File Offset: 0x0002D06A
		// (set) Token: 0x060008D7 RID: 2263 RVA: 0x0002EE72 File Offset: 0x0002D072
		public List<ReactorAction> Reactors
		{
			get
			{
				return this._Reactors;
			}
			set
			{
				this._Reactors = value;
			}
		}

		// Token: 0x17000262 RID: 610
		// (get) Token: 0x060008D8 RID: 2264 RVA: 0x0002EE7B File Offset: 0x0002D07B
		// (set) Token: 0x060008D9 RID: 2265 RVA: 0x0002EE83 File Offset: 0x0002D083
		public List<ActorCoreEffect> Effects
		{
			get
			{
				return this._Effects;
			}
			set
			{
				this._Effects = value;
			}
		}

		// Token: 0x060008DA RID: 2266 RVA: 0x0002EE8C File Offset: 0x0002D08C
		protected virtual void Awake()
		{
			if (this._AttributeSourceOwner != null)
			{
				this.AttributeSource = InterfaceHelper.GetComponent<IAttributeSource>(this._AttributeSourceOwner);
			}
			if (this.AttributeSource == null)
			{
				this.AttributeSource = InterfaceHelper.GetComponent<IAttributeSource>(base.gameObject);
				if (this.AttributeSource != null)
				{
					this._AttributeSourceOwner = base.gameObject;
				}
			}
			this.InstantiateStates();
			this.InstantiateReactors();
			this.InstantiateEffects();
		}

		// Token: 0x060008DB RID: 2267 RVA: 0x0002EEF8 File Offset: 0x0002D0F8
		public void InstantiateStates()
		{
			this.mStateHash.Clear();
			for (int i = 0; i < this._States.Count; i++)
			{
				this.mStateHash.Add(this._States[i]._Name, i);
			}
		}

		// Token: 0x060008DC RID: 2268 RVA: 0x0002EF43 File Offset: 0x0002D143
		public bool StateExists(string rName)
		{
			return this.mStateHash.ContainsKey(rName);
		}

		// Token: 0x060008DD RID: 2269 RVA: 0x0002EF54 File Offset: 0x0002D154
		public void RemoveState(string rName)
		{
			bool flag = false;
			for (int i = this._States.Count - 1; i >= 0; i--)
			{
				if (string.Compare(this._States[i]._Name, rName) == 0)
				{
					flag = true;
					this._States.RemoveAt(i);
				}
			}
			if (flag)
			{
				this.InstantiateStates();
			}
		}

		// Token: 0x060008DE RID: 2270 RVA: 0x0002EFAB File Offset: 0x0002D1AB
		public int GetStateValue(string rName)
		{
			if (this.mStateHash.ContainsKey(rName))
			{
				return this._States[this.mStateHash[rName]].Value;
			}
			return 0;
		}

		// Token: 0x060008DF RID: 2271 RVA: 0x0002EFDC File Offset: 0x0002D1DC
		public void SetStateValue(string rName, int rValue)
		{
			if (!this.mStateHash.ContainsKey(rName))
			{
				ActorCoreState actorCoreState = new ActorCoreState();
				actorCoreState.Name = rName;
				actorCoreState.Value = rValue;
				this._States.Add(actorCoreState);
				this.InstantiateStates();
			}
			int value = this._States[this.mStateHash[rName]].Value;
			this._States[this.mStateHash[rName]].Value = rValue;
			int num = 0;
			while (num < this._Reactors.Count && (!this._Reactors[num].IsEnabled || !this._Reactors[num].TestActivate(value, rValue) || this.Reactors[num].Activate()))
			{
				num++;
			}
		}

		// Token: 0x060008E0 RID: 2272 RVA: 0x0002F0A8 File Offset: 0x0002D2A8
		public void InstantiateReactors()
		{
			int count = this._ReactorDefinitions.Count;
			for (int i = this._Reactors.Count - 1; i >= count; i--)
			{
				this._Reactors.RemoveAt(i);
			}
			for (int j = 0; j < count; j++)
			{
				string text = this._ReactorDefinitions[j];
				Type type = JSONSerializer.GetType(text);
				if (!(type == null))
				{
					ReactorAction reactorAction;
					if (this._Reactors.Count <= j || !type.Equals(this._Reactors[j].GetType()))
					{
						reactorAction = Activator.CreateInstance(type) as ReactorAction;
						reactorAction.Owner = base.gameObject;
						if (this._Reactors.Count <= j)
						{
							this._Reactors.Add(reactorAction);
						}
						else
						{
							this._Reactors[j] = reactorAction;
						}
					}
					else
					{
						reactorAction = this._Reactors[j];
					}
					if (reactorAction != null)
					{
						reactorAction.Deserialize(text);
					}
				}
			}
			for (int k = 0; k < this._Reactors.Count; k++)
			{
				this._Reactors[k].Owner = base.gameObject;
				this._Reactors[k].Awake();
			}
		}

		// Token: 0x060008E1 RID: 2273 RVA: 0x0002F1EA File Offset: 0x0002D3EA
		public virtual void AddReactor(ReactorAction rReactor)
		{
			this._Reactors.Add(rReactor);
			this._ReactorDefinitions.Add(rReactor.Serialize());
			rReactor.Owner = base.gameObject;
			rReactor.Awake();
		}

		// Token: 0x060008E2 RID: 2274 RVA: 0x0002F21C File Offset: 0x0002D41C
		public virtual void RemoveReactor(ReactorAction rReactor)
		{
			for (int i = 0; i < this._Reactors.Count; i++)
			{
				if (this._Reactors[i] == rReactor)
				{
					this._Reactors.RemoveAt(i);
					this._ReactorDefinitions.RemoveAt(i);
					return;
				}
			}
		}

		// Token: 0x060008E3 RID: 2275 RVA: 0x0002F268 File Offset: 0x0002D468
		public virtual ReactorAction GetReactor(string rNameID)
		{
			for (int i = 0; i < this._Reactors.Count; i++)
			{
				if (string.Compare(this._Reactors[i].Name, rNameID) == 0)
				{
					return this._Reactors[i];
				}
			}
			return null;
		}

		// Token: 0x060008E4 RID: 2276 RVA: 0x0002F2B4 File Offset: 0x0002D4B4
		public virtual T GetReactor<T>(string rName = null) where T : ReactorAction
		{
			Type typeFromHandle = typeof(T);
			for (int i = 0; i < this._Reactors.Count; i++)
			{
				if ((rName == null || string.Compare(this._Reactors[i].Name, rName) == 0) && this._Reactors[i].GetType() == typeFromHandle)
				{
					return (T)((object)this._Reactors[i]);
				}
			}
			return default(T);
		}

		// Token: 0x060008E5 RID: 2277 RVA: 0x0002F334 File Offset: 0x0002D534
		public void InstantiateEffects()
		{
			int count = this._EffectDefinitions.Count;
			for (int i = this._Effects.Count - 1; i >= count; i--)
			{
				this._Effects.RemoveAt(i);
			}
			for (int j = 0; j < count; j++)
			{
				string text = this._EffectDefinitions[j];
				Type type = JSONSerializer.GetType(text);
				if (!(type == null))
				{
					ActorCoreEffect actorCoreEffect;
					if (this._Effects.Count <= j || !type.Equals(this._Effects[j].GetType()))
					{
						actorCoreEffect = Activator.CreateInstance(type) as ActorCoreEffect;
						actorCoreEffect.ActorCore = this;
						if (this._Effects.Count <= j)
						{
							this._Effects.Add(actorCoreEffect);
						}
						else
						{
							this._Effects[j] = actorCoreEffect;
						}
					}
					else
					{
						actorCoreEffect = this._Effects[j];
					}
					if (actorCoreEffect != null)
					{
						actorCoreEffect.Deserialize(text);
					}
				}
			}
			for (int k = 0; k < this._Effects.Count; k++)
			{
				this._Effects[k].Awake();
			}
		}

		// Token: 0x060008E6 RID: 2278 RVA: 0x0002F45C File Offset: 0x0002D65C
		public virtual ActorCoreEffect GetActiveEffectFromName(string rName)
		{
			for (int i = 0; i < this._Effects.Count; i++)
			{
				if (string.Compare(this._Effects[i].Name, rName) == 0)
				{
					return this._Effects[i];
				}
			}
			return null;
		}

		// Token: 0x060008E7 RID: 2279 RVA: 0x0002F4A8 File Offset: 0x0002D6A8
		public virtual T GetActiveEffectFromName<T>(string rName = null) where T : ActorCoreEffect
		{
			for (int i = 0; i < this._Effects.Count; i++)
			{
				if ((rName == null || string.Compare(this._Effects[i].Name, rName) == 0) && this._Effects[i].GetType() == typeof(T))
				{
					return (T)((object)this._Effects[i]);
				}
			}
			return default(T);
		}

		// Token: 0x060008E8 RID: 2280 RVA: 0x0002F524 File Offset: 0x0002D724
		public virtual T GetActiveEffectFromSourceID<T>(string rSourceID) where T : ActorCoreEffect
		{
			for (int i = 0; i < this._Effects.Count; i++)
			{
				if (string.Compare(this._Effects[i].SourceID, rSourceID) == 0 && this._Effects[i].GetType() == typeof(T))
				{
					return (T)((object)this._Effects[i]);
				}
			}
			return default(T);
		}

		// Token: 0x060008E9 RID: 2281 RVA: 0x0002F59D File Offset: 0x0002D79D
		public ReactorActionEvent GetStoredUnityEvent(int rIndex)
		{
			if (rIndex < 0 || rIndex >= this._StoredUnityEvents.Count)
			{
				return null;
			}
			return this._StoredUnityEvents[rIndex];
		}

		// Token: 0x060008EA RID: 2282 RVA: 0x0002F5BF File Offset: 0x0002D7BF
		public ReactorActionEvent GetStoredGameObject(ref int rIndex)
		{
			if (rIndex < 0 || rIndex >= this._StoredUnityEvents.Count)
			{
				rIndex = -1;
				return null;
			}
			if (this._StoredUnityEvents[rIndex] == null)
			{
				rIndex = -1;
				return null;
			}
			return this._StoredUnityEvents[rIndex];
		}

		// Token: 0x060008EB RID: 2283 RVA: 0x0002F5FC File Offset: 0x0002D7FC
		public int StoreUnityEvent(int rIndex, ReactorActionEvent rObject)
		{
			int num = rIndex;
			if (rObject == null)
			{
				if (num >= 0 && num < this._StoredUnityEvents.Count)
				{
					this._StoredUnityEvents[num] = null;
				}
				num = -1;
			}
			else
			{
				if (num == -1)
				{
					num = this._StoredUnityEvents.Count;
					this._StoredUnityEvents.Add(null);
				}
				this._StoredUnityEvents[num] = rObject;
			}
			return num;
		}

		// Token: 0x060008EC RID: 2284 RVA: 0x0002F65C File Offset: 0x0002D85C
		public void SendMessage(IMessage rMessage)
		{
			int num = 0;
			while (num < this._Reactors.Count && (!this._Reactors[num].IsEnabled || !this._Reactors[num].TestActivate(rMessage) || this._Reactors[num].Activate()))
			{
				num++;
			}
		}

		// Token: 0x060008ED RID: 2285 RVA: 0x0002F6BC File Offset: 0x0002D8BC
		protected virtual void Update()
		{
			for (int i = 0; i < this._Reactors.Count; i++)
			{
				ReactorAction reactorAction = this._Reactors[i];
				if (reactorAction._IsEnabled && reactorAction._IsActive)
				{
					reactorAction.Update();
				}
			}
			for (int j = 0; j < this._Effects.Count; j++)
			{
				ActorCoreEffect actorCoreEffect = this._Effects[j];
				if (!actorCoreEffect.Update())
				{
					this._Effects.RemoveAt(j);
					j--;
					actorCoreEffect.Release();
				}
			}
		}

		// Token: 0x060008EE RID: 2286 RVA: 0x0002F743 File Offset: 0x0002D943
		public virtual bool TestAffected(IMessage rMessage)
		{
			return true;
		}

		// Token: 0x060008EF RID: 2287 RVA: 0x0002F748 File Offset: 0x0002D948
		public virtual bool OnDamaged(DamageMessage rMessage)
		{
			if (!this.IsAlive)
			{
				return true;
			}
			float num = 0f;
			if (this.AttributeSource != null && rMessage != null)
			{
				num = this.AttributeSource.GetAttributeValue<float>(this.HealthID, 0f) - rMessage.Damage;
				this.AttributeSource.SetAttributeValue<float>(this.HealthID, num);
			}
			if (num <= 0f)
			{
				this.OnKilled(rMessage);
			}
			else if (rMessage != null)
			{
				bool flag = true;
				if (rMessage != null)
				{
					flag = rMessage.AnimationEnabled;
				}
				if (flag)
				{
					MotionController component = base.gameObject.GetComponent<MotionController>();
					if (component != null)
					{
						rMessage.ID = CombatMessage.MSG_DEFENDER_DAMAGED;
						component.SendMessage(rMessage);
					}
					if (!rMessage.IsHandled && this.DamagedMotion.Length > 0)
					{
						MotionControllerMotion motionControllerMotion = null;
						if (component != null)
						{
							motionControllerMotion = component.GetMotion(this.DamagedMotion, false);
						}
						if (motionControllerMotion != null)
						{
							component.ActivateMotion(motionControllerMotion, 0);
						}
						else if (Animator.StringToHash(this.DeathMotion) != 0)
						{
							Animator component2 = base.gameObject.GetComponent<Animator>();
							if (component2 != null)
							{
								component2.CrossFade(this.DamagedMotion, 0.25f, 0);
							}
						}
					}
				}
			}
			return true;
		}

		// Token: 0x060008F0 RID: 2288 RVA: 0x0002F868 File Offset: 0x0002DA68
		public virtual void OnKilled(DamageMessage rMessage)
		{
			this.IsAlive = false;
			if (this.AttributeSource != null && this.HealthID.Length > 0)
			{
				this.AttributeSource.SetAttributeValue<float>(this.HealthID, 0f);
			}
			base.StartCoroutine(this.InternalDeath(rMessage));
		}

		// Token: 0x060008F1 RID: 2289 RVA: 0x0002F8B6 File Offset: 0x0002DAB6
		protected virtual IEnumerator InternalDeath(IMessage rMessage)
		{
			ActorController lActorController = base.gameObject.GetComponent<ActorController>();
			MotionController lMotionController = base.gameObject.GetComponent<MotionController>();
			if (rMessage != null && lMotionController != null)
			{
				rMessage.ID = CombatMessage.MSG_DEFENDER_KILLED;
				lMotionController.SendMessage(rMessage);
				if (!rMessage.IsHandled && this.DeathMotion.Length > 0)
				{
					MotionControllerMotion motion = lMotionController.GetMotion(this.DeathMotion, false);
					if (motion != null)
					{
						lMotionController.ActivateMotion(motion, 0);
					}
					else if (Animator.StringToHash(this.DeathMotion) != 0)
					{
						Animator component = base.gameObject.GetComponent<Animator>();
						if (component != null)
						{
							try
							{
								component.CrossFade(this.DeathMotion, 0.25f, 0);
							}
							catch
							{
							}
						}
					}
				}
				yield return new WaitForSeconds(3f);
				lMotionController.enabled = false;
				lMotionController.ActorController.enabled = false;
			}
			Collider[] components = base.gameObject.GetComponents<Collider>();
			for (int i = 0; i < components.Length; i++)
			{
				components[i].enabled = false;
			}
			if (lActorController != null)
			{
				lActorController.RemoveBodyShapes();
			}
			yield break;
		}

		// Token: 0x060008F3 RID: 2291 RVA: 0x0002F959 File Offset: 0x0002DB59
		GameObject ILifeCore.get_gameObject()
		{
			return base.gameObject;
		}

		// Token: 0x04000488 RID: 1160
		public GameObject _AttributeSourceOwner;

		// Token: 0x04000489 RID: 1161
		[NonSerialized]
		protected IAttributeSource mAttributeSource;

		// Token: 0x0400048A RID: 1162
		public bool _IsAlive = true;

		// Token: 0x0400048B RID: 1163
		public string _HealthID = "Health";

		// Token: 0x0400048C RID: 1164
		public string _DamagedMotion = "Damaged";

		// Token: 0x0400048D RID: 1165
		public string _DeathMotion = "Death";

		// Token: 0x0400048E RID: 1166
		public List<ActorCoreState> _States = new List<ActorCoreState>();

		// Token: 0x0400048F RID: 1167
		public List<ReactorAction> _Reactors = new List<ReactorAction>();

		// Token: 0x04000490 RID: 1168
		public List<string> _ReactorDefinitions = new List<string>();

		// Token: 0x04000491 RID: 1169
		public List<ActorCoreEffect> _Effects = new List<ActorCoreEffect>();

		// Token: 0x04000492 RID: 1170
		public List<string> _EffectDefinitions = new List<string>();

		// Token: 0x04000493 RID: 1171
		public List<ReactorActionEvent> _StoredUnityEvents = new List<ReactorActionEvent>();

		// Token: 0x04000494 RID: 1172
		protected Dictionary<string, int> mStateHash = new Dictionary<string, int>(StringComparer.OrdinalIgnoreCase);
	}
}
