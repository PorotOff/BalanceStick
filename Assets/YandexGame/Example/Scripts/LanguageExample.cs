using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.UI;

namespace YG.Example
{
	public class LanguageExample : MonoBehaviour
	{
		[SerializeField] string ru;
		[SerializeField] string en;
		[SerializeField] string tr;

		Text textObj;

        [SerializeField] private Text bestScoreText;

        private void Awake()
		{
			textObj = GetComponent<Text>();
			//SwitchLanguage(YandexGame.savesData.language);
		}

		private void OnEnable() => YandexGame.SwitchLangEvent += SwitchLanguage;
		private void OnDisable() => YandexGame.SwitchLangEvent -= SwitchLanguage;

		public void SwitchLanguage(string language)
		{
            bestScoreText.text = $"BEST\n{YandexGame.savesData.playerBestScore}";
            Debug.Log("сейчас язык: " + language);
            if (language == "ru")
            {
                bestScoreText.text = $"ЛУЧШИЙ\n{YandexGame.savesData.playerBestScore}";
                Debug.Log("Перевод произошёл");
            }

   //         switch (language)
			//{
			//	case "ru":
			//		textObj.text = ru;
			//		break;
			//	case "tr":
			//		textObj.text = tr;
			//		break;
			//	default:
			//		textObj.text = en;
			//		break;
			//}
		}
		public void CheckLanguage()
		{
            YandexGame.LanguageRequest();
        }
	}
}