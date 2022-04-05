using UnityEngine;
using UnityEngine.UI;

public class LoginOrRegister : MonoBehaviour
{
    PlayerAccount _playerAccount;

    [SerializeField] InputField _loginUsername, _email, _password, _rPassword;
    [SerializeField] Button _loginOrRegisterButton;
    [SerializeField] Text _title,_RegisterOrLoginButtonText, _orRegisterLogin;

    public bool _isRegisterActive { get; set; }

    private void Awake()
    {
       _playerAccount = new PlayerAccount();
      // _loginOrRegisterButton.interactable = false;
    }
    public void Register()
    {
        _playerAccount.LoginUsername = _loginUsername.text;
        _playerAccount.Email = _email.text;
        _playerAccount.Password = _password.text;
        _playerAccount.RepeatPassword = _rPassword.text;
        _playerAccount.DisplayName = _loginUsername.text;
        _playerAccount.Register();
    }
    //public void InputCheckControl()
    //{
    //    if (_loginUsername.text.Length >= 6 && (_password.text == _rPassword.text) && (_password.text != "") && _password.text.Length >= 6)
    //    {
    //        _loginOrRegisterButton.interactable = true;
    //    }
    //    else
    //    {
    //        _loginOrRegisterButton.interactable = false;
    //    }
    //}

    public void InputPasswordColorControl()
    {
        if (/*_password.text != _rPassword.text ||*/ _password.text.Length < 6)
        {
            _password.image.color = Color.red;
        }
        else
        {
            _password.image.color = Color.green;
        }
    }
    public void InputRPassWordColorControl()
    {
        if (_rPassword.text.Length < 6)
        {
            _rPassword.image.color = Color.red;
        }
        else
        {
            _rPassword.image.color = Color.green;
        }
    }
    public void InputUsernameColorControl()
    {
        if (_loginUsername.text.Length > 6)
        {
            _loginUsername.image.color = Color.green;
        }

        else
        {
            _loginUsername.image.color = Color.red;
        }
    }
    public void InputEmailColorControl()
    {
        if (_email.text.IndexOf('@') <= 0)
        {
            _email.image.color = Color.red;
        }

        else
        {
            _email.image.color = Color.green;
        }
    }

    public void Login()
    {
        _playerAccount.LoginUsername = _loginUsername.text;
        _playerAccount.Password = _password.text;
        _playerAccount.Login();
    }

    public void RegisterOrLoginPanelControl()
    {
        switch (!_email.gameObject.activeInHierarchy)
        {
            case true:
                RegisterPanel();
                break;
            case false:
                LoginPanel();
                break;
        }
    }

    void RegisterPanel()
    {
        _title.text = "Register";
        _email.gameObject.SetActive(true);
        _rPassword.gameObject.SetActive(true);
        _RegisterOrLoginButtonText.text = "Register";
        _orRegisterLogin.text = "Or Login";
        _loginOrRegisterButton.onClick.RemoveAllListeners(); // butonun ıcındekılerı sılıyor.
        _loginOrRegisterButton.onClick.AddListener(Register);
    }
    void LoginPanel()
    {
        _title.text = "Login";
        _email.gameObject.SetActive(false);
        _rPassword.gameObject.SetActive(false);
        _RegisterOrLoginButtonText.text = "Login";
        _orRegisterLogin.text = "Or Register";
        _loginOrRegisterButton.onClick.RemoveAllListeners(); // butonun ıcındekılerı sılıyor.
        _loginOrRegisterButton.onClick.AddListener(Login);
    }
}
