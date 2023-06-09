﻿using Monopoly;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Monopoly
{
    abstract class PropertyAbstact : Property
    {
        public PropertyAbstact(Property prop, Player play)
        {
            this.name = prop.name;
            this.buying_cost = prop.buying_cost;
            this.type = prop.type;
            this.owner = play;
            this.position = prop.position;
        }

        public string toStringOwner()
        {
            return "\tName: " + name + "\n\tType: " + type.ToString() + "\n\tBuying cost: $" + buying_cost + "\n\tTaxes: $" + taxes +
                "\n\tSituation: " + situation.ToString() + "\n\tOwner: " + owner.name;
        }
    }

    class BoughtProperty : PropertyAbstact
    {
        public BoughtProperty(Property prop, Player play) : base(prop, play)
        {
            this.taxes = prop.buying_cost / 2;
            this.situation = PropertySituation.Bought;
        }
    }

    class HouseProperty : BoughtProperty
    {
        public HouseProperty(BoughtProperty prop, Player play) : base(prop, play)
        {
            this.taxes = prop.taxes * 2;
            this.situation = PropertySituation.House;
        }
    }

    class HotelProperty : HouseProperty
    {
        public HotelProperty(HouseProperty prop, Player play) : base(prop, play)
        {
            this.taxes = prop.taxes * 2;
            this.situation = PropertySituation.Hotel;
        }
    }
}
