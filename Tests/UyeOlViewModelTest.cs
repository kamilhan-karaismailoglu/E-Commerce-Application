using Autofac.Extras.Moq;
using NUnit.Framework;
using FluentAssertions;
using AutoFixture;
using System.Threading.Tasks;
using System.Linq;
using Moq;
using HatemogluApp.Models;
using HatemogluApp.ViewModels;
using System.Windows.Documents;
using Xunit;
using MvvmHelpers.Commands;

namespace HatemogluApp.Tests
{
    [TestFixture]
    public class UyeOlViewModelTest
{
        private Fixture _fixture;

        public UyeOlViewModelTest() => _fixture = new Fixture();

        [Test]
        public void CreatingUyeOlViewModel_WhenSuccessfull_NewUserIsEmpty()
        {
            using (var mock = AutoMock.GetLoose())
            {
                var viewModel = mock.Create<UyeOlViewModel>();
                viewModel.NewUser.Should().BeNull();
            }
        }

        [Test]
        public void CreatingUyeOlViewModel_WhenSuccessfull_EntryiesAreEmpty()
        {
            using (var mock = AutoMock.GetLoose())
            {
                var viewModel = mock.Create<UyeOlViewModel>();

                viewModel.Name.Should().BeNull();
                viewModel.Surname.Should().BeNull();
                viewModel.Phone.Should().BeNull();
                viewModel.Mail.Should().BeNull();
                viewModel.Password.Should().BeNull();
                viewModel.Password2.Should().BeNull();
                viewModel.SozlesmeIsChecked.Should().BeFalse();
            }
        }

        [Test]
        public void CreatingUyeOlViewModel_WhenSuccessfull_InitializesCommands()
        {
            using (var mock = AutoMock.GetLoose())
            {
                var viewModel = mock.Create<UyeOlViewModel>();

                viewModel.KaydeButtonCommand.Should().NotBeNull();
                viewModel.KaydeButtonCommand.Should().BeOfType<Command>(); 
                
                viewModel.SozlesmeCommand.Should().NotBeNull();
                viewModel.SozlesmeCommand.Should().BeOfType<Command>();

                viewModel.SepetCommand.Should().NotBeNull();
                viewModel.SepetCommand.Should().BeOfType<Command>();

                viewModel.LogoCommand.Should().NotBeNull();
                viewModel.SepetCommand.Should().BeOfType<Command>();
            }
        }
    }
}
