$('#formLogin').on('submit', function (e) {
  e.preventDefault();

  $.ajax({
    url: `${API_URL}/auth/login`,
    method: 'POST',
    contentType: 'application/json',
    data: JSON.stringify({
      username: $('#username').val(),
      password: $('#password').val()
    }),
    success: function (res) {
      localStorage.setItem('token', res.token);
      window.location.href = 'pedidos.html';
    },
    error: function () {
      alert('Usuário ou senha inválidos.');
    }
  });
});
