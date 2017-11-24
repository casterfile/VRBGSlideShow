namespace GoogleVR.GVRDemo {
  	using UnityEngine;
	using System.Collections;
	using UnityEngine.Video;
	using UnityEngine.UI;

	public class SceneControllerSlideShow : MonoBehaviour {
		private  GameObject[] objVideo,objPicture;
		private  VideoPlayer[] VideoPlayerControl;
		private string[] VideoURL;
		private int totalLoop = 0;
		private int CurrentPicture = 0,CurrentVideo = 0;
		private bool isVideo = false;
		private float timeMouseDown = 0.0f;
		public bool mouseDown = false;
		private string NameAction = "";
		private int IntAction = -1;
		private GameObject StartGameButton;

	    void Start() {
			int ArrayLength = 9;
			totalLoop = ArrayLength - 1;
			objVideo = new GameObject[ArrayLength];
			objPicture = new GameObject[ArrayLength];
			VideoURL = new string[ArrayLength];
			VideoPlayerControl = new VideoPlayer[ArrayLength];
			FindAllVideos ();
			URLSetting ();
			HideAllVideos ();
//			StartCoroutine(Transition());
			objPicture [4].SetActive (true);
//			TransitionStart();
	    }

		void Update() {
			if (mouseDown == true) {
				timeMouseDown += Time.deltaTime;
				//				print ("timeMouseDown: "+timeMouseDown);
				if(timeMouseDown >= 2){
					if(NameAction == "Video"){
						Controller("Video",IntAction);
						OnPointerUp ();
					}
				}
			}
		}

		private void Controller(string Output,int OutputNumber)
		{
			if(Output == "Video"){
				HideAllVideos ();
				TransitionStart();
				StartGameButton.SetActive (false);
			}
		}

		public void SceneVideo(){
			mouseDown = true;
			NameAction = "Video";
		}

		public void OnPointerUp(){
			mouseDown = false;
			timeMouseDown = 0;
		}

		private void HideAllVideos(){
			for (int x = 0; x <= totalLoop; x++) {
				objVideo [x].SetActive(false);
				objPicture [x].SetActive(false);
			}
		}


		private void FindAllVideos(){
//			objVideo [0]=  GameObject.Find("360 Videos (0)");
			for (int x = 0; x <= totalLoop; x++) {
				print ("COunt: "+ x);
				objVideo[x] =  GameObject.Find("VideoList/360 Videos ("+x+")");
				VideoPlayerControl[x] =  objVideo[x].GetComponent<VideoPlayer>();
				objPicture[x] =  GameObject.Find("PhotoList/360 Photo ("+x+")");


//				objVideo [x].SetActive(false);
//				objPicture [x].SetActive(false);
			}
			StartGameButton =  GameObject.Find("StartGame");
	
		}
		private void TransitionStart(){
			HideAllVideos ();
			isVideo = !isVideo;
			if (isVideo == true) {
				if(CurrentVideo == totalLoop){
					CurrentVideo = 0;
				}
				objVideo [CurrentPicture].SetActive (true);
				CurrentVideo++;
				StartCoroutine(Transition());
			} else {
				if(CurrentPicture == totalLoop){
					CurrentPicture = 0;
				}
				objPicture [CurrentPicture].SetActive (true);
				CurrentPicture++;
				StartCoroutine(Transition());
			}

		}


		IEnumerator Transition()
		{
			yield return new WaitForSeconds(25);
			TransitionStart ();
		}


		void URLSetting(){
//			VideoURL[0] = "https://wptest.bgbridalgallery.com.ph/wp-content/uploads/2017/10/Sample-Video.mp4";
//			VideoURL[1] = "https://wptest.bgbridalgallery.com.ph/wp-content/uploads/2017/10/Sample-Video.mp4";
//			VideoURL[2] = "https://wptest.bgbridalgallery.com.ph/wp-content/uploads/2017/10/Sample-Video.mp4";
//			VideoURL[3] = "https://wptest.bgbridalgallery.com.ph/wp-content/uploads/2017/10/Sample-Video.mp4";
//			VideoURL[4] = "https://wptest.bgbridalgallery.com.ph/wp-content/uploads/2017/10/Sample-Video.mp4";
//			VideoURL[5] = "https://wptest.bgbridalgallery.com.ph/wp-content/uploads/2017/10/Sample-Video.mp4";
//			VideoURL[6] = "https://wptest.bgbridalgallery.com.ph/wp-content/uploads/2017/10/Sample-Video.mp4";
//			VideoURL[7] = "https://wptest.bgbridalgallery.com.ph/wp-content/uploads/2017/10/Sample-Video.mp4";
//			VideoURL[8] = "https://wptest.bgbridalgallery.com.ph/wp-content/uploads/2017/10/Sample-Video.mp4";
//
//			for (int x = 0; x <= totalLoop; x++) {
//				VideoPlayerControl [x].source = VideoSource.Url;
//				VideoPlayerControl [x].url = VideoURL[x];
//			}
		}

  }
}

