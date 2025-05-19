using WebmilioCommonsAddon.Helpers;
using Laugicality.Utilities.Players;

namespace Laugicality.Utilities.Focuses
{

    public class FocusManager : SingletonManager<FocusManager, Focus>
    {
        private static FocusManager _instance;
        public static FocusManager Instance => _instance ??= new FocusManager();
        public FocusManager()
        {
            DefaultInitialize();
        }

        public override void DefaultInitialize()
        {
            Vitality = Add(new VitalityFocus());
            Tenacity = Add(new TenacityFocus());
            Mobility = Add(new MobilityFocus());
            Utility = Add(new UtilityFocus());
            Ferocity = Add(new FerocityFocus());
            Capacity = Add(new CapacityFocus());

            Vitality.RegisterEnemies(new Focus[] { Mobility, Ferocity });
            Vitality.RegisterNemeses(Utility);

            Tenacity.RegisterEnemies(new Focus[] { Utility, Capacity });
            Tenacity.RegisterNemeses(Ferocity);

            Mobility.RegisterEnemies(new Focus[] { Ferocity, Vitality });
            Mobility.RegisterNemeses(Capacity);

            Utility.RegisterEnemies(new Focus[] { Capacity, Tenacity });
            Utility.RegisterNemeses(Vitality);

            Ferocity.RegisterEnemies(new Focus[] { Vitality, Mobility });
            Ferocity.RegisterNemeses(Tenacity);

            Capacity.RegisterEnemies(new Focus[] { Tenacity, Utility });
            Capacity.RegisterNemeses(Mobility);

            ForAllItems(f => f.ManagerEndInitialization());
            base.DefaultInitialize();
        }


        public Focus Vitality { get; private set; }

        public Focus Tenacity { get; private set; }

        public Focus Mobility { get; private set; }

        public Focus Utility { get; private set; }

        public Focus Ferocity { get; private set; }

        public Focus Capacity { get; private set; }
    }
}