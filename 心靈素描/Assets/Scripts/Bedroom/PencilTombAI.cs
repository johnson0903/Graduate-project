using UnityEngine;
using System.Collections;
using System;
using System.Collections.Generic;
using UnityEngine.SceneManagement;

public class PencilTombAI : MonoBehaviour {

	public GameObject boxCutter;

	private GameObject player;
	private DialogHolder dialogHolder;
	private static bool beenDrivenAway;
	private static bool isBoxCutterTaken;

	private static int pencilTombTalkCount;

	// Use this for initialization
	void Start()
	{
		player = FindObjectOfType<PlayerController>().gameObject;
		dialogHolder = this.GetComponent<DialogHolder>();
		this.GetComponent<DialogHolder> ().DialogOverEvent += OnDialogOver;
	}

	// Update is called once per frame
	void Update()
	{
		if (pencilTombTalkCount == 0) {
			if (!beenDrivenAway)
				dialogHolder.Dialogs = new List<Dialog> {
					dialogHolder.TalkDialog ("一枝大大的鉛筆插在土堆上"),
					dialogHolder.TalkDialog ("像是墳墓一樣..."),
					dialogHolder.AskDialog ("挖挖看", "摸摸看", new List<Dialog> {
						dialogHolder.TalkDialog ("冰冰涼涼的觸感 摸起來很舒服"),
						dialogHolder.TalkDialog ("泥土好像動了一下"),
						dialogHolder.TalkDialog ("是錯覺吧？")
					}),
					dialogHolder.TalkDialog ("土有點硬...."),
					dialogHolder.TalkDialog ("沙沙沙沙....."),
					dialogHolder.TalkDialog ("「喂 你小子！」"),
					dialogHolder.TalkDialog (".......？！"),
					dialogHolder.TalkDialog ("「你媽沒教你沒經過別人允許不要隨便挖別人身體嗎？」"),
					dialogHolder.TalkDialog ("從...從墳墓裡...聲音...？"),
					dialogHolder.TalkDialog ("「真是的...土壤太乾已經讓我很不舒服了」"),
					dialogHolder.TalkDialog ("「你來這裡做什麼的？」"),
					dialogHolder.AskDialog ("不知道", "這裡是哪裡呢？", new List<Dialog> {
						dialogHolder.TalkDialog ("「你不知道這裡是哪嗎？」"),
						dialogHolder.TalkDialog ("「這裡是由我那偉大的主人所創造出來的 只屬於我的世界喔！」"),
						dialogHolder.TalkDialog ("「雖然這個世界有點小」"),
						dialogHolder.TalkDialog ("「不過反正我也不能移動 所以沒差」"),
						dialogHolder.TalkDialog ("「話說 你這傢伙是誰啊 主人新畫出來的嗎？」"),
						dialogHolder.TalkDialog ("我從外面進來的..."),
						dialogHolder.TalkDialog ("「外面？原來人類做得到這種事嗎？」"),
						dialogHolder.TalkDialog ("「這樣的話 真希望主人能夠進來摸摸我啊」"),
						dialogHolder.TalkDialog ("「啊....講太多話身體好乾...土要裂開了」"),
						dialogHolder.TalkDialog ("「這個世界的乾季還真是難熬 要是有一點水的話...」"),
						dialogHolder.TalkDialog ("「不跟你說了 再說我背上的鉛筆都要掉下來了」")
					}),
					dialogHolder.TalkDialog ("「不知道還來煩我？」"),
					dialogHolder.TalkDialog ("「給我滾出去！」")
				};
			else
				dialogHolder.Dialogs = new List<Dialog> {
					dialogHolder.TalkDialog ("「又是你」"),
					dialogHolder.TalkDialog ("「你來這裡做什麼的？」"),
					dialogHolder.AskDialog ("不知道", "這裡是哪裡呢？", new List<Dialog> {
						dialogHolder.TalkDialog ("「你不知道這裡是哪嗎？」"),
						dialogHolder.TalkDialog ("「這裡是由我那偉大的主人所創造出來的 只屬於我的世界喔！」"),
						dialogHolder.TalkDialog ("「雖然這個世界有點小」"),
						dialogHolder.TalkDialog ("「不過反正我也不能移動 所以沒差」"),
						dialogHolder.TalkDialog ("「話說 你這傢伙是誰啊 主人新畫出來的嗎？」"),
						dialogHolder.TalkDialog ("我從外面進來的..."),
						dialogHolder.TalkDialog ("「外面？原來人類做得到這種事嗎？」"),
						dialogHolder.TalkDialog ("「這樣的話 真希望主人能夠進來摸摸我啊」"),
						dialogHolder.TalkDialog ("「啊....講太多話身體好乾...土要裂開了」"),
						dialogHolder.TalkDialog ("「這個世界的乾季還真是難熬 要是有一點水的話...」"),
						dialogHolder.TalkDialog ("「不跟你說了 再說我背上的鉛筆都要掉下來了」")
					}),
					dialogHolder.TalkDialog ("「........」"),
					dialogHolder.TalkDialog ("「滾」")
				};
		} else if (pencilTombTalkCount == 1) {
			if (player.GetComponent<PlayerInventory> ().isSomethingInInventory ("Water"))
				dialogHolder.Dialogs = new List<Dialog> {
					dialogHolder.TalkDialog ("「啊....」"),
					dialogHolder.TalkDialog ("「好乾啊......」"),
					dialogHolder.AskDialog ("把水澆在土上", "那個....", new List<Dialog> {
						dialogHolder.TalkDialog ("「不要跟我說話」"),
						dialogHolder.TalkDialog ("「啊....啊..啊」")
					}),
					dialogHolder.TalkDialog ("「喔喔....喔喔喔喔！」"),
					dialogHolder.TalkDialog ("「終....終於下雨了嗎」"),
					dialogHolder.TalkDialog ("「不對啊 乾季怎麼會下雨」"),
					dialogHolder.TalkDialog ("那個..."),
					dialogHolder.TalkDialog ("「喔 是你啊！」"),
					dialogHolder.TalkDialog ("「太好了你這傢伙 立大功啦！」"),
					dialogHolder.TalkDialog ("「這樣的濕度 應該可以撐到雨季了」"),
					dialogHolder.TalkDialog ("「太棒了 該怎麼感謝你呢？」"),
					dialogHolder.TalkDialog ("「啊 就讓你挖我的身體吧 裡面有很多好東西喔」"),
					dialogHolder.TalkDialog ("謝..謝謝你"),
					dialogHolder.TalkDialog ("沙沙沙....."),
					dialogHolder.PickUpItemDialog ("獲得了 美工刀", boxCutter),
					dialogHolder.TalkDialog ("「感謝你喔 好心的傢伙！」")
				};
			else
				dialogHolder.Dialogs = new List<Dialog> {
					dialogHolder.TalkDialog ("「啊....」"),
					dialogHolder.TalkDialog ("「好乾啊......」"),
				};
		} else if (pencilTombTalkCount >= 2) {
			dialogHolder.Dialogs = new List<Dialog> {
				dialogHolder.TalkDialog ("「啊....」"),
				dialogHolder.TalkDialog ("「太陽好舒服.....」"),
			};
		}
	}

	void OnDialogOver (object sender, EventArgs e)
	{
		if (pencilTombTalkCount == 0) {
			if (beenDrivenAway) {
				if (dialogHolder.AskDialogAnswerList [0] == 1) {
					beenDrivenAway = true;
					player.GetComponent<PlayerController> ().MoveToOriginPositionX ();
					SceneManager.LoadScene (0);
				} else
					pencilTombTalkCount++;
						
			} else {
				if (dialogHolder.AskDialogAnswerList [0] == 1) {
					if (dialogHolder.AskDialogAnswerList [1] == 1) {
						beenDrivenAway = true;
						player.GetComponent<PlayerController> ().MoveToOriginPositionX ();
						SceneManager.LoadScene (0);
					} else if (dialogHolder.AskDialogAnswerList [1] == 2) {
						pencilTombTalkCount++;
					}
				} 
			}
		}
		if (pencilTombTalkCount == 1) {
			if (player.GetComponent<PlayerInventory> ().isSomethingInInventory ("Water") && dialogHolder.AskDialogAnswerList [0] == 1) {
				isBoxCutterTaken = true;
				pencilTombTalkCount++;
			}
		}
	}
}
