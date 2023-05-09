using Assets.Code.ChessData;
using Assets.Code.ChessData.Enums;
using Assets.Code.ChessData.Pieces;
using Assets.Code.ChessData.Pieces.UpgradeData;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TMPro;
using UnityEditor;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

namespace Assets.Code.Upgrades
{
    internal class UpgradeItemController : MonoBehaviour
    {
        UpgradeDataModel upgradeDataModel;

        public void loadUpgradeModel(UpgradeDataModel model)
        {
            upgradeDataModel = model;
            loadIntoChildrenGameObjects();
        }

        private void loadIntoChildrenGameObjects()
        {
            Debug.Log($"Loading into children. {this.transform.childCount}");

            GameObject UpgradeNameGameObject = this.transform.GetChild(0).gameObject;
            GameObject CostGameObject = this.transform.GetChild(1).gameObject;
            GameObject ButtonGameObject = this.transform.GetChild(2).gameObject;

            TextMeshProUGUI upgradeNameText = UpgradeNameGameObject.GetComponent<TextMeshProUGUI>();
            TextMeshProUGUI costText = CostGameObject.GetComponent<TextMeshProUGUI>();
            Button button = ButtonGameObject.GetComponent<Button>();

            if(upgradeNameText != null)
            {
                Debug.Log($"Setting upgrade name text to {upgradeDataModel.UpgradeType}");
                upgradeNameText.text = upgradeDataModel.UpgradeType.ToString();
            }

            if(costText != null)
            {
                Debug.Log($"Setting upgrade cost text to {upgradeDataModel.UpgradeType}");
                costText.text = upgradeDataModel.UpgradeCost.ToString();
            }

            if(button != null)
            {
                button.onClick.AddListener(UpgradeChessPiece);
            }
        }

        private void UpgradeChessPiece()
        {
            GameObject newChessPiece = Instantiate(ChessPieceContainer.getChessPiecePrefabByType(upgradeDataModel.UpgradeType));
            newChessPiece.transform.position = ChessBoardComponent.currentlySelectedChessPiece.transform.position;
            Destroy(ChessBoardComponent.currentlySelectedChessPiece.gameObject);
            ChessBoardComponent.CurrentlySelectedChessPiece = newChessPiece.GetComponent<ChessPieceComponent>();
            newChessPiece.transform.SetParent(ChessPieceContainer.instance.gameObject.transform);
        }

    }
}