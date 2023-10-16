﻿using SignUpApp.Domain.Services.AuthenticationServices;
using SignUpApp.WPF.State.Authenticators;
using SignUpApp.WPF.State.Navigators;
using SignUpApp.WPF.ViewModels;
using System;
using System.Windows.Input;

namespace SignUpApp.WPF.Commands
{
    public class RegisterCommand : ICommand
    {
        private readonly RegisterViewModel _registerViewModel;
        private readonly IAuthenticator _authenticator;
        private readonly IRenavigator _registerRenavigator;

        public RegisterCommand(RegisterViewModel registerViewModel, IAuthenticator authenticator, IRenavigator registerRenavigator)
        {
            _registerViewModel = registerViewModel;
            _authenticator = authenticator;
            _registerRenavigator = registerRenavigator;
        }

        public event EventHandler CanExecuteChanged;

        public bool CanExecute(object parameter)
        {
            return true;
        }
        public async void Execute(object parameter)
        {
            _registerViewModel.ErrorMessage = string.Empty;

            try
            {
                RegistrationResult registrationResult = await _authenticator.Register(
                       _registerViewModel.Email,
                       _registerViewModel.Username,
                       _registerViewModel.Password,
                       _registerViewModel.ConfirmPassword);

                switch (registrationResult)
                {
                    case RegistrationResult.Success:
                        _registerRenavigator.Renavigate();
                        break;
                    case RegistrationResult.PasswordsDoNotMatch:
                        _registerViewModel.ErrorMessage = "Password does not match confirm password.";
                        break;
                    case RegistrationResult.EmailAlreadyExists:
                        _registerViewModel.ErrorMessage = "An account for this email already exists.";
                        break;
                    case RegistrationResult.UserNameAlreadyExists:
                        _registerViewModel.ErrorMessage = "An account for this username already exists.";
                        break;
                    default:
                        _registerViewModel.ErrorMessage = "Registration failed.";
                        break;
                }
            }
            catch (Exception)
            {
                _registerViewModel.ErrorMessage = "Registration failed.";
            }
        }

        //public override async Task ExecuteAsync(object parameter)
        //{
        //    _registerViewModel.ErrorMessage = string.Empty;

        //    try
        //    {
        //        RegistrationResult registrationResult = await _authenticator.Register(
        //               _registerViewModel.Email,
        //               _registerViewModel.Username,
        //               _registerViewModel.Password,
        //               _registerViewModel.ConfirmPassword);

        //        switch (registrationResult)
        //        {
        //            case RegistrationResult.Success:
        //                _registerRenavigator.Renavigate();
        //                break;
        //            case RegistrationResult.PasswordsDoNotMatch:
        //                _registerViewModel.ErrorMessage = "Password does not match confirm password.";
        //                break;
        //            case RegistrationResult.EmailAlreadyExists:
        //                _registerViewModel.ErrorMessage = "An account for this email already exists.";
        //                break;
        //            case RegistrationResult.UserNameAlreadyExists:
        //                _registerViewModel.ErrorMessage = "An account for this username already exists.";
        //                break;
        //            default:
        //                _registerViewModel.ErrorMessage = "Registration failed.";
        //                break;
        //        }
        //    }
        //    catch (Exception)
        //    {
        //        _registerViewModel.ErrorMessage = "Registration failed.";
        //    }
        //}
    }
}
