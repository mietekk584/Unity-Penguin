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
W powy�szym skrypcie mamy zmienn� jumpButton, 
kt�ra jest oznaczona jako [SerializeField], 
co umo�liwia przypisanie jej referencji do obiektu przycisku w edytorze Unity.
Mamy r�wnie� publiczn� zmienn� isButtonPressed, 
kt�ra b�dzie ustawiana na true po naci�ni�ciu przycisku i na false po jego zwolnieniu. 
Funkcja OnJumpButtonClicked jest wywo�ywana po klikni�ciu przycisku, 
a funkcja Update sprawdza, czy przycisk zosta� zwolniony przy pomocy myszy
(przyjmuje si�, �e lewy przycisk myszy oznacza zwolnienie jumpButton).

Pami�taj, aby do��czy� ten skrypt do obiektu w Twojej scenie, 
a nast�pnie przypisa� obiekt przycisku do pola jumpButton w inspektorze Unity.



*/