using Assets.Code.ChessData.Pieces;
using Assets.Code.ChessData.Pieces.UpgradeData;
using Assets.Code.Upgrades;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Assets.Code.Interactions
{
    public class UpgradeRowControllerComponent : MonoBehaviour
    {
        [SerializeField]
        public GameObject upgradeItemGO;

        private static UpgradeRowControllerComponent singleInstance;

        public UpgradeRowControllerComponent()
        {
            singleInstance = this;
        }

        public static void ShowUpgradesOfChessPiece(ChessPieceComponent chessPiece)
        {
            if (singleInstance == null)
            {
                throw new System.Exception("No upgrade row component was set.");
            }

            if (chessPiece == null)
            {
                singleInstance.gameObject.SetActive(false);
                return;
            }

            LoadUpgradeRow(chessPiece);
            if(singleInstance.transform.childCount > 0)
            {
                singleInstance.gameObject.SetActive(true);
            }
        }

        private static void LoadUpgradeRow(ChessPieceComponent chessPiece)
        {
            RemoveAllPreviousUpgrades();

            LoadCurrentUpgrades(chessPiece);
        }

        private static void LoadCurrentUpgrades(ChessPieceComponent chessPiece)
        {
            List<UpgradeDataModel> availableUpgrades = UpgradeDataLibrary.GetUpgradeDataForChessPiece(chessPiece.PieceType);

            foreach (UpgradeDataModel upgradeDataModel in availableUpgrades)
            {
                singleInstance.addUpgradeOption(upgradeDataModel);
            }
        }

        private void addUpgradeOption(UpgradeDataModel upgradeDataModel)
        {
            if(upgradeItemGO == null)
            {
                throw new Exception("No prefab was set for upgrade item.");
            }

            GameObject UpgradeItem = Instantiate(upgradeItemGO);

            UpgradeItemController itemController = UpgradeItem.AddComponent<UpgradeItemController>();
            itemController.loadUpgradeModel(upgradeDataModel);

            UpgradeItem.transform.SetParent(singleInstance.transform);
        }

        private static void RemoveAllPreviousUpgrades()
        {
            foreach (Transform child in singleInstance.gameObject.transform)
            {
                Destroy(child.gameObject);
            }
        }
    }
}