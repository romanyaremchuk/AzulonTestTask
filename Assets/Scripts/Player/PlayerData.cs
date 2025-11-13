using Currency;

namespace Player
{
    public class PlayerData : BaseGlobalRuntimeData
    {
        private Wallet _wallet;

        public Wallet Wallet
        {
            get => _wallet;
            set => _wallet = value;
        }
    }
}