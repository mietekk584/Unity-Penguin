using UnityEngine;
using UnityEngine.UI;

public class TestJumpButton : MonoBehaviour {
    [SerializeField] private Button jumpButton;
    public bool isButtonPressed;

    private void Start() {
        jumpButton.onClick.AddListener(OnJumpButtonClicked);
    }

    private void OnJumpButtonClicked() {
        isButtonPressed = true;
        print(isButtonPressed);
    }

    private void Update() {
        if (Input.GetMouseButtonUp(0)) // Assuming left mouse button for releasing the jumpButton
        {
            isButtonPressed = false;
            print(isButtonPressed);
        }
    }
}


/* 
W powy¿szym skrypcie mamy zmienn¹ jumpButton, 
która jest oznaczona jako [SerializeField], 
co umo¿liwia przypisanie jej referencji do obiektu przycisku w edytorze Unity.
Mamy równie¿ publiczn¹ zmienn¹ isButtonPressed, 
która bêdzie ustawiana na true po naciœniêciu przycisku i na false po jego zwolnieniu. 
Funkcja OnJumpButtonClicked jest wywo³ywana po klikniêciu przycisku, 
a funkcja Update sprawdza, czy przycisk zosta³ zwolniony przy pomocy myszy
(przyjmuje siê, ¿e lewy przycisk myszy oznacza zwolnienie jumpButton).

Pamiêtaj, aby do³¹czyæ ten skrypt do obiektu w Twojej scenie, 
a nastêpnie przypisaæ obiekt przycisku do pola jumpButton w inspektorze Unity.



*/