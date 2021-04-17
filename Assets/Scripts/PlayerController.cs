using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.Characters.FirstPerson;

public class PlayerController : MonoBehaviour
{

    public Inventory inventory;

    private PlayerSelection selection;
    private FirstPersonController firstPersonController;

    [SerializeField] CanvasController canvasController;


    private bool usingFPSController = true;
    public bool UsingFPSController
    {
        get {return usingFPSController;}

        private set { usingFPSController = value; }
    }

    internal void EnableInputs(bool enalbe )
    {
        UsingFPSController = enalbe;

        firstPersonController.GetMouseLook.SetCursorLock(enalbe);
        firstPersonController.enabled = enalbe;
        selection.enabled = enalbe;        
    }

    private void Awake()
    {
        firstPersonController = GetComponent<FirstPersonController>();
        selection = GetComponent<PlayerSelection>();
        selection.onSelectionClicked.AddListener( OnSelectedObject );
    }

    private void OnItemDropped(GameObject arg0)
    {
        ToggleInventoryMode();
    }

    private void OnSelectedObject(GameObject pickUp)
    {        
        //Add to inventory
        inventory.AddItem( pickUp.GetComponent<IColectable>().ColectItem() );        
    }


    // Start is called before the first frame update
    void Start()
    {
        canvasController.onItemDropped.AddListener(OnItemDropped);
    }

    private void OnItemDropped()
    {
        ToggleInventoryMode();
    }

    // Update is called once per frame
    void Update()
    {
        //Enable/Disable Inventory
        if (Input.GetMouseButtonDown(1))
        {
            ToggleInventoryMode();
        }

        if (Input.GetKeyDown(KeyCode.Escape))
        {
            //quit ?
            QuitGame();
        }
    }


    private void QuitGame()
    {
        EnableInputs(false);
        GameController.instance.QuitPressed();
    }

    private void ToggleInventoryMode()
    {
        UsingFPSController = !UsingFPSController;

        firstPersonController.GetMouseLook.SetCursorLock(UsingFPSController);
        firstPersonController.enabled = UsingFPSController;
        selection.enabled = UsingFPSController;

        ShowInventory(!usingFPSController);
    }

    private void ShowInventory(bool show)
    {
        if(canvasController)
            canvasController.ShowInventoryPanel(show);
    }

    private void OnDestroy()
    {
        selection.onSelectionClicked.RemoveListener( OnSelectedObject );
        canvasController.onItemDropped.RemoveListener(OnItemDropped);

    }

}
