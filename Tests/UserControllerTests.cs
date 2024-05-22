using CRUD_application_2.Controllers;
using CRUD_application_2.Interfaces;
using CRUD_application_2.Models;
using Moq;
using NUnit.Framework;
using System.Collections.Generic;
using System.Web.Mvc;

[TestFixture]
public class UserControllerTests
{
    private Mock<IUserService> _userServiceMock;
    private UserController _userController;

    [SetUp]
    public void Setup()
    {
        _userServiceMock = new Mock<IUserService>();
        _userController = new UserController();//_userServiceMock.Object);
    }

    [Test]
    public void Index_WhenCalled_ReturnsViewResult()
    {
        // Arrange
        var users = new List<User> { new User { Id = 1, Name = "Test User" } };
        _userServiceMock.Setup(s => s.GetUsers()).Returns(users);

        // Act
        var result = _userController.Index() as ViewResult;

        // Assert
        Assert.IsNotNull(result);
        var model = result.Model as List<User>;
        Assert.AreEqual(users, model);
    }

    [Test]
    public void Details_WhenCalledWithExistingId_ReturnsViewResult()
    {
        // Arrange
        var user = new User { Id = 1, Name = "Test User" };
        _userServiceMock.Setup(s => s.GetUser(1)).Returns(user);

        // Act
        var result = _userController.Details(1) as ViewResult;

        // Assert
        Assert.IsNotNull(result);
        var model = result.Model as User;
        Assert.AreEqual(user, model);
    }

    [Test]
    public void Create_Post_WhenCalled_AddsUserAndReturnsRedirectResult()
    {
        // Arrange
        var newUser = new User { Name = "New User" };
        _userServiceMock.Setup(s => s.AddUser(newUser)).Verifiable();

        // Act
        var result = _userController.Create(newUser) as RedirectToRouteResult;

        // Assert
        _userServiceMock.Verify();
        Assert.IsNotNull(result);
        Assert.AreEqual("Index", result.RouteValues["action"]);
    }

    [Test]
    public void Edit_Post_WhenCalledWithExistingId_UpdatesUserAndReturnsRedirectResult()
    {
        // Arrange
        var existingUser = new User { Id = 1, Name = "Existing User" };
        _userServiceMock.Setup(s => s.UpdateUser(existingUser)).Verifiable();

        // Act
        var result = _userController.Edit(existingUser.Id) as RedirectToRouteResult;

        // Assert
        _userServiceMock.Verify();
        Assert.IsNotNull(result);
        Assert.AreEqual("Index", result.RouteValues["action"]);
    }

    [Test]
    public void Delete_Post_WhenCalledWithExistingId_DeletesUserAndReturnsRedirectResult()
    {
        // Arrange
        var userId = 1;
        _userServiceMock.Setup(s => s.DeleteUser(userId)).Verifiable();

        // Act
        var result = _userController.Delete(userId) as RedirectToRouteResult;

        // Assert
        _userServiceMock.Verify();
        Assert.IsNotNull(result);
        Assert.AreEqual("Index", result.RouteValues["action"]);
    }
}
