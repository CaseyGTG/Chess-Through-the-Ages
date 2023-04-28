using Assets.Code.ChessData.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assets.Code.ChessData.Pieces.UpgradeData
{
    internal class UpgradeDataModel
    {
        public UpgradeDataModel(ChessPieceType upgradeType, int upgradeCost)
        {
            UpgradeType = upgradeType;
            UpgradeCost = upgradeCost;
        }
        public ChessPieceType UpgradeType { get; set; }

        public int UpgradeCost { get; set; }
    }
}
