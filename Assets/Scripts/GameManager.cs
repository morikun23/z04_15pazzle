//担当：森田　勝
//概要：クラス全体を管理するクラス
//　　　Unityから直接コールされる
//　　　MVCパターンで実装されており、Logic（Model）とViewを持っている
//参考：なし

using UnityEngine;

namespace Z04 {
	public class GameManager : MonoBehaviour {

		#region Singleton実装
		private static GameManager _instance;

		public static GameManager Instance {
			get {
				if (_instance == null) {
					_instance = FindObjectOfType<GameManager>();
				}
				return _instance;
			}
		}

		private GameManager() { }

		#endregion

		//Logic(Model)
		public Logic.LogicManager _logicManager { get; private set; }

		//View
		public View.ViewManager _viewManager { get; private set; }

		//ゲームの操作を行うもの
		IPlayable _player;

		// Use this for initialization
		void Start() {

			//FPSの設定
			Application.targetFrameRate = Config.FPS;

			//リソースの取得
			ResourceManager.Instance.Initialize();

			_logicManager = new Logic.LogicManager();
			_viewManager = new View.ViewManager();
			
			_logicManager.Initialize();
			_viewManager.Initialize(_logicManager);

			_player = new Player();
			_player.Initialize();
		}

		// Update is called once per frame
		void Update() {
			_logicManager.UpdateByFrame();
			_viewManager.UpdateByFrame();
			_player.UpdateByFrame();
		}
	}
}