using CustomHint.API;
using Exiled.API.Features;
using Exiled.API.Features.Roles;
using System;

namespace CRCHPlaceholder
{
    public class CRCHPlaceholder : Plugin<Config>
    {
        public override string Name => "CRCHPlaceholder";
        public override string Author => "Chuppa2";
        public override Version Version => new Version(1, 0, 0);
        public override Version RequiredExiledVersion => new Version(9, 0, 0);

        public override void OnEnabled()
        {
            PlaceholderManager.RegisterPlayerPlaceholder("{custominfo}", GetCustomInfo);
            Log.Debug("Placeholder {custominfo} registered successfully.");
            base.OnEnabled();
        }

        private string GetCustomInfo(Player player)
        {
            if (player == null)
                return "No Player Found";

            if (!(player.Role is SpectatorRole sr))
                return "Not Spectator";

            var spectatedPlayer = sr.SpectatedPlayer;

            if (spectatedPlayer == null)
                return "No Spectated Player";

            return string.IsNullOrEmpty(spectatedPlayer.CustomInfo)
                ? "Not Custom Role"
                : spectatedPlayer.CustomInfo;
        }

        public override void OnDisabled()
        {
            base.OnDisabled();
        }
    }
}