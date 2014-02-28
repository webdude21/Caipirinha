using System;
using System.Text;

namespace KnightsOfCSharpiaLib.Creatures
{
    using Items;
    using Newtonsoft.Json;
    using Newtonsoft.Json.Linq;
    using System.Collections.Generic;

    [JsonObject(MemberSerialization.OptIn)]
    public abstract class Hero : Unit, IScalable, ICombatant
    {
        public static Hero LoadState(string json)
        {
            int typeNameEndIndex = json.IndexOf(Environment.NewLine.ToString());

            string typeName = json.Substring(0, typeNameEndIndex - 2);
            string parsableJson = json.Remove(0, typeNameEndIndex - 1);

            JObject jsonObject = JObject.Parse(parsableJson);

            JToken inventory = jsonObject["Inventory"];
            JToken equipment = jsonObject["Equipment"];

            jsonObject.Remove("Inventory");
            jsonObject.Remove("Equipment");

            Hero result;

            if (typeName == "Warrior")
            {
                result = JsonConvert.DeserializeObject<Warrior>(jsonObject.ToString());
            }
            else
            {
                result = JsonConvert.DeserializeObject<Mage>(jsonObject.ToString());
            }

            foreach (var item in inventory["InventoryContent"])
            {
                result.Inventory.AddItem(Item.ParseFromJson(item.ToString()));
            }

            foreach (var item in equipment["Items"])
            {
                result.EquipItem(Item.ParseFromJson(item.ToString()));
            }

            if (result.GetType().Name == "Warrior")
            {
                return result as Warrior;
            }
            else
            {
                return result as Mage;
            }
        }

        public delegate void LevelUpHandler();

        public event LevelUpHandler LevelUpEvent;

        protected Hero(string name)
            : base(name)
        {
            this.Equipment = new Equipment();
            this.NeededXP = 100;
            this.CurrentXp = 0;
            this.Inventory = new Inventory();
        }

        public string Statistics
        {
            get
            {
                return this.ToString();
            }
        }

        [JsonProperty(Order=12)]
        public Inventory Inventory { get; protected set; }

        [JsonProperty(Order=7)]
        public uint Strength { get; protected set; }

        [JsonProperty(Order=8)]
        public uint Dexterity { get; protected set; }

        [JsonProperty(Order=9)]
        public uint Intelligence { get; protected set; }

        [JsonProperty(Order=9)]
        public uint WillPower { get; protected set; }

        [JsonProperty(Order=13)]
        public Equipment Equipment { get; protected set; }

        [JsonProperty(Order=11)]
        public uint CurrentXp { get; private set; }

        [JsonProperty(Order=10)]
        public uint NeededXP { get; private set; }

        public void EquipItem(Item item)
        {
            if (item == null)
            {
                return;
            }
            this.Equipment.AddItem(item);
            this.Strength += item.StrengthModifier;
            this.Dexterity += item.DexterityModifier;
            this.Intelligence += item.IntelligenceModifier;
            this.WillPower += item.WillPowerModifier;
        }

        public void UnEquipItem(Item item)
        {
            if (item == null)
            {
                return;
            }
            this.Equipment.RemoveItem(item);
            this.Strength -= item.StrengthModifier;
            this.Dexterity -= item.DexterityModifier;
            this.Intelligence -= item.IntelligenceModifier;
            this.WillPower -= item.WillPowerModifier;
        }

        public void AddXP(uint xp)
        {
            this.CurrentXp += xp;
            if (this.CurrentXp > this.NeededXP)
            {
                if (this.LevelUpEvent != null)
                {
                    this.LevelUpEvent();
                }

                this.LevelUp();
            }
        }

        public virtual void LevelUp()
        {
            this.Level++;
            this.CurrentXp -= this.NeededXP;
            this.NeededXP = (uint)(this.NeededXP * 1.4);
        }

        public override void Update()
        {
            this.CurrentMana += (int)this.Intelligence * 3;

            if (this.CurrentMana > this.MaxMana)
            {
                this.CurrentMana = (int)this.MaxMana;
            }
        }

        public virtual void UpdateAfterBattle()
        {
            this.CurrentHealth += (int)this.Strength * 5 + (int)this.Level * 10;
            if (this.CurrentHealth > this.MaxHealth)
            {
                this.CurrentHealth = (int)this.MaxHealth;
            }

            this.CurrentMana += (int)this.Intelligence * 5 + (int)this.Level * 10;
            if (this.CurrentMana > this.MaxMana)
            {
                this.CurrentMana = (int)this.MaxMana;
            }
        }

        public virtual string SaveState()
        {
            string result = JsonConvert.SerializeObject(this, Formatting.Indented);
            result = result.Insert(0, String.Format("{0}\n", this.GetType().Name));
            return result;
        }

        public override string ToString()
        {
            var stringBuilder = new StringBuilder();
            stringBuilder.Append(string.Format("Name: {0}", this.Name));
            stringBuilder.Append(Environment.NewLine);
            stringBuilder.Append(string.Format("Level: {0}", this.Level));
            stringBuilder.Append(Environment.NewLine);
            stringBuilder.Append(string.Format("XP: {0}/{1}", this.CurrentXp, this.NeededXP));
            stringBuilder.Append(Environment.NewLine);
            stringBuilder.Append(string.Format("Health: {0}/{1}", this.CurrentHealth, this.MaxHealth));
            stringBuilder.Append(Environment.NewLine);
            stringBuilder.Append(string.Format("Mana: {0}/{1}", this.CurrentMana, this.MaxMana));
            stringBuilder.Append(Environment.NewLine);
            stringBuilder.Append(string.Format("Strength: {0}", this.Strength));
            stringBuilder.Append(Environment.NewLine);
            stringBuilder.Append(string.Format("Dexterity: {0}", this.Dexterity));
            stringBuilder.Append(Environment.NewLine);
            stringBuilder.Append(string.Format("Intelligence: {0}", this.Intelligence));
            stringBuilder.Append(Environment.NewLine);
            stringBuilder.Append(string.Format("Will Power: {0}", this.WillPower));
            return stringBuilder.ToString();
        }
    }
}
