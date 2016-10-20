using UnityEngine;
using System.Collections;
using System;
using System.Collections.Generic;

public class FourCrossAI : MonoBehaviour {

	public string description;
	public GameObject bones;

	private PlayerInventory playerInventory;
	private DialogHolder dialogHolder;
	private bool isPuzzleOver;

	private GameObject currentMask;
	private static bool isBoneTaken;

	// Use this for initialization
	void Start()
	{
		playerInventory = FindObjectOfType<PlayerInventory> ();
		dialogHolder = this.GetComponent<DialogHolder> ();
		this.GetComponent<DialogHolder> ().DialogOverEvent += OnDialogOver;
	}

	// Update is called once per frame
	void Update()
	{
		if (!isPuzzleOver) {
			if (currentMask == null) {
				List<Dialog> dialog1 = new List<Dialog> ();
				List<Dialog> dialog2 = new List<Dialog> ();
				List<Dialog> dialog3 = new List<Dialog> ();
				List<Dialog> dialog4 = new List<Dialog> ();

				dialogHolder.Dialogs = new List<Dialog> { 
					dialogHolder.TalkDialog ("在地上聳立著黑色的十字架"),
					dialogHolder.TalkDialog ("上面好像有刻字..."),
					dialogHolder.TalkDialog (description),
					dialogHolder.TalkDialog ("十字架中間有一個像是可以放進什麼東西的凹槽"),
					dialogHolder.TalkDialog ("要放上哪一種面具呢？")
				};

				if (playerInventory.IsSomethingInInventory ("BoringMask")) {
					dialog4 = new List<Dialog> {
						dialogHolder.AskDialog ("無表情的面具", "離開", new List<Dialog>{ dialogHolder.TalkDialog ("再想想看") }),
						dialogHolder.TalkDialog ("放上了 無表情的面具")
					};
				}

				if (playerInventory.IsSomethingInInventory ("SadMask")) {
					if (playerInventory.IsSomethingInInventory ("BoringMask"))
						dialog3 = new List<Dialog> {
							dialogHolder.AskDialog ("悲傷的面具", "其他", dialog4),
							dialogHolder.TalkDialog ("放上了 悲傷的面具")
						};
					else
						dialog3 = new List<Dialog> {
							dialogHolder.AskDialog ("悲傷的面具", "離開", new List<Dialog>{ dialogHolder.TalkDialog ("再想想看") }),
							dialogHolder.TalkDialog ("放上了 悲傷的面具")
						};
				}

				if (playerInventory.IsSomethingInInventory ("AngryMask")) {
					if (playerInventory.IsSomethingInInventory ("SadMask"))
						dialog2 = new List<Dialog> {
							dialogHolder.AskDialog ("生氣的面具", "其他", dialog3),
							dialogHolder.TalkDialog ("放上了 生氣的面具")
						};
					else if (playerInventory.IsSomethingInInventory ("BoringMask"))
						dialog2 = new List<Dialog> {
							dialogHolder.AskDialog ("生氣的面具", "其他", dialog4),
							dialogHolder.TalkDialog ("放上了 生氣的面具")
						};
					else
						dialog2 = new List<Dialog> {
							dialogHolder.AskDialog ("生氣的面具", "離開", new List<Dialog>{ dialogHolder.TalkDialog ("再想想看") }),
							dialogHolder.TalkDialog ("放上了 生氣的面具")
						};
				}

				if (playerInventory.IsSomethingInInventory ("HappyMask")) {
					if (playerInventory.IsSomethingInInventory ("AngryMask"))
						dialog1 = new List<Dialog> {
							dialogHolder.AskDialog ("快樂的面具", "其他", dialog2),
							dialogHolder.TalkDialog ("放上了 快樂的面具")
						};
					else if (playerInventory.IsSomethingInInventory ("SadMask"))
						dialog1 = new List<Dialog> {
							dialogHolder.AskDialog ("快樂的面具", "其他", dialog3),
							dialogHolder.TalkDialog ("放上了 快樂的面具")
						};
					else if (playerInventory.IsSomethingInInventory ("BoringMask"))
						dialog1 = new List<Dialog> {
							dialogHolder.AskDialog ("快樂的面具", "其他", dialog4),
							dialogHolder.TalkDialog ("放上了 快樂的面具")
						};
					else
						dialog1 = new List<Dialog> {
							dialogHolder.AskDialog ("快樂的面具", "離開", new List<Dialog>{ dialogHolder.TalkDialog ("再想想看") }),
							dialogHolder.TalkDialog ("放上了 快樂的面具")
						};
				}	

				if (playerInventory.IsSomethingInInventory ("HappyMask"))
					dialogHolder.Dialogs.AddRange (dialog1);
				else if (playerInventory.IsSomethingInInventory ("AngryMask"))
					dialogHolder.Dialogs.AddRange (dialog2);
				else if (playerInventory.IsSomethingInInventory ("SadMask"))
					dialogHolder.Dialogs.AddRange (dialog3);
				else if (playerInventory.IsSomethingInInventory ("BoringMask"))
					dialogHolder.Dialogs.AddRange (dialog4);
				else
					dialogHolder.Dialogs.RemoveRange (4, 1);
			
			} else
				dialogHolder.Dialogs = new List<Dialog> { 
					dialogHolder.TalkDialog ("在地上聳立著黑色的十字架"),
					dialogHolder.TalkDialog ("上面好像有刻字..."),
					dialogHolder.TalkDialog (description),
					dialogHolder.TalkDialog ("十字架中間放著 " + currentMask.GetComponent<ItemData> ().itemName),
					dialogHolder.TalkDialog ("要拿下來嗎？"),
					dialogHolder.AskDialog ("是", "否", new List<Dialog> { dialogHolder.TalkDialog ("放在這是對的嗎？") }),
					dialogHolder.TalkDialog ("拿下了 " + currentMask.GetComponent<ItemData> ().itemName)
				};
		} else {
			if (this.gameObject.name == "HappyCross") {
				if (!isBoneTaken)
					dialogHolder.Dialogs = new List<Dialog> { 
						dialogHolder.TalkDialog ("本來帶著快樂面具的十字架突然斷成了兩截"),
						dialogHolder.TalkDialog ("面具也不知道為什麼消失了"),
						dialogHolder.TalkDialog ("在十字架的內部發現了一些堅硬的東西"),
						dialogHolder.PickUpItemDialog ("獲得了 骨頭堆", bones)
					};
				else
					dialogHolder.Dialogs = new List<Dialog> { 
						dialogHolder.TalkDialog ("本來帶著快樂面具的十字架斷成了兩截"),
						dialogHolder.TalkDialog ("給人一種淒涼的感覺...")
					};
			} else
				dialogHolder.Dialogs = new List<Dialog> { 
					dialogHolder.TalkDialog ("在地上聳立著帶著" + currentMask.GetComponent<ItemData> ().itemName + "的十字架")
				};
		}
	}

	public void WearMask(GameObject whatMaskToWear){
		currentMask = Instantiate (whatMaskToWear);
		currentMask.name = whatMaskToWear.name;
		currentMask.transform.SetParent (this.transform);
		if (this.gameObject.name == "HappyCross") {
			currentMask.transform.localScale = new Vector3 (3.2f, 3.2f, 1);
			currentMask.transform.localPosition = new Vector3 (0, 2.1f, 0);
		} else if (this.gameObject.name == "SadCross") {
			currentMask.transform.localScale = new Vector3 (4f, 4f, 1);
			currentMask.transform.localPosition = new Vector3 (0, 4f, 0);
		} else if (this.gameObject.name == "BoringCross") {
			currentMask.transform.localScale = new Vector3 (3.5f, 3.5f, 1);
			currentMask.transform.localPosition = new Vector3 (0, 2f, 0);
		} else if (this.gameObject.name == "AngryCross") {
			currentMask.transform.localScale = new Vector3 (5f, 4f, 1);
			currentMask.transform.localPosition = new Vector3 (0, 5.5f, 0);
		}
	}

	void OnDialogOver(object sender, EventArgs e)
	{
		if (!isPuzzleOver) {
			if (currentMask == null) {
				if (dialogHolder.AskDialogAnswerList.Count > 0 && dialogHolder.AskDialogAnswerList [0] == 1) {
					if (playerInventory.IsSomethingInInventory ("HappyMask")) {
						WearMask (playerInventory.GetSomethingInInventory ("HappyMask"));
						playerInventory.DropItem ("HappyMask");
					} else if (playerInventory.IsSomethingInInventory ("AngryMask")) {
						WearMask (playerInventory.GetSomethingInInventory ("AngryMask"));
						playerInventory.DropItem ("AngryMask");
					} else if (playerInventory.IsSomethingInInventory ("SadMask")) {
						WearMask (playerInventory.GetSomethingInInventory ("SadMask"));
						playerInventory.DropItem ("SadMask");
					} else if (playerInventory.IsSomethingInInventory ("BoringMask")) {
						WearMask (playerInventory.GetSomethingInInventory ("BoringMask"));
						playerInventory.DropItem ("BoringMask");
					}
				} else if (dialogHolder.AskDialogAnswerList.Count > 1 && dialogHolder.AskDialogAnswerList [1] == 1) {
					if (playerInventory.IsSomethingInInventory ("HappyMask")) {
						if (playerInventory.IsSomethingInInventory ("AngryMask")) {
							WearMask (playerInventory.GetSomethingInInventory ("AngryMask"));
							playerInventory.DropItem ("AngryMask");	
						} else if (playerInventory.IsSomethingInInventory ("SadMask")) {
							WearMask (playerInventory.GetSomethingInInventory ("SadMask"));
							playerInventory.DropItem ("SadMask");
						} else if (playerInventory.IsSomethingInInventory ("BoringMask")) {
							WearMask (playerInventory.GetSomethingInInventory ("BoringMask"));
							playerInventory.DropItem ("BoringMask");
						}
					} else if (playerInventory.IsSomethingInInventory ("AngryMask")) {
						if (playerInventory.IsSomethingInInventory ("SadMask")) {
							WearMask (playerInventory.GetSomethingInInventory ("SadMask"));
							playerInventory.DropItem ("SadMask");
						} else if (playerInventory.IsSomethingInInventory ("BoringMask")) {
							WearMask (playerInventory.GetSomethingInInventory ("BoringMask"));
							playerInventory.DropItem ("BoringMask");
						}
					} else if (playerInventory.IsSomethingInInventory ("SadMask")) {
						if (playerInventory.IsSomethingInInventory ("BoringMask")) {
							WearMask (playerInventory.GetSomethingInInventory ("BoringMask"));
							playerInventory.DropItem ("BoringMask");
						}
					}
				} else if (dialogHolder.AskDialogAnswerList.Count > 2 && dialogHolder.AskDialogAnswerList [2] == 1) {
					if (playerInventory.IsSomethingInInventory ("HappyMask")) {
						if (playerInventory.IsSomethingInInventory ("AngryMask")) {
							if (playerInventory.IsSomethingInInventory ("SadMask")) {
								WearMask (playerInventory.GetSomethingInInventory ("SadMask"));
								playerInventory.DropItem ("SadMask");
							} else if (playerInventory.IsSomethingInInventory ("BoringMask")) {
								WearMask (playerInventory.GetSomethingInInventory ("BoringMask"));
								playerInventory.DropItem ("BoringMask");
							}
						} else if (playerInventory.IsSomethingInInventory ("SadMask")) {
							if (playerInventory.IsSomethingInInventory ("BoringMask")) {
								WearMask (playerInventory.GetSomethingInInventory ("BoringMask"));
								playerInventory.DropItem ("BoringMask");
							}
						}
					} else if (playerInventory.IsSomethingInInventory ("AngryMask")) {
						if (playerInventory.IsSomethingInInventory ("SadMask")) {
							if (playerInventory.IsSomethingInInventory ("BoringMask")) {
								WearMask (playerInventory.GetSomethingInInventory ("BoringMask"));
								playerInventory.DropItem ("BoringMask");
							}
						} 
					}
				} else if (dialogHolder.AskDialogAnswerList.Count > 3 && dialogHolder.AskDialogAnswerList [3] == 1) {
					if (playerInventory.IsSomethingInInventory ("BoringMask")) {
						WearMask (playerInventory.GetSomethingInInventory ("BoringMask"));
						playerInventory.DropItem ("BoringMask");
					}
				}
				
			} else if (dialogHolder.AskDialogAnswerList.Count > 0 && dialogHolder.AskDialogAnswerList [0] == 1) {
				if (this.transform.childCount > 1) {
					playerInventory.PickUpItem (this.transform.GetChild (1).gameObject);
					GameObject.Destroy (this.transform.GetChild (1));	
				}
			}
		} else if (this.gameObject.name == "HappyCross")
			isBoneTaken = true;
	}

	public bool IsPuzzleOver {
		set{ isPuzzleOver = value; }
	}

	public GameObject CurrentMask {
		get { return currentMask; }
	}

}
