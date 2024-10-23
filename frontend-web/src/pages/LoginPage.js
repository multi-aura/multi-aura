import React, { useState } from 'react';
import { useNavigate } from 'react-router-dom'; 
import LogoSection from '../components/LogoSection/LogoSection'; 
import LoginForm from '../components/LoginForm/LoginForm';
import logoImage from '../assets/img/Logo.png';
import { login } from '../services/authService';
import '../assets/css/LoginPage.css';
function LoginPage() {
  const [errorMessage, setErrorMessage] = useState(''); 
  const navigate = useNavigate();
  const handleLogin = async (credentials) => {
    try {
      const response = await login(credentials.username, credentials.password); 
      console.log('Đăng nhập thành công:', response);
      try {
        navigate('/Home', { state: { userData: response.data } });
      } catch (error) {
        console.error('Lỗi điều hướng:', error);
      }

    } catch (error) {
      if (error.response && error.response.status === 500) {
        setErrorMessage('Lỗi hệ thống. Vui lòng thử lại sau.'); 
      } else if (error.response && error.response.status === 400) {
        setErrorMessage('Thông tin đăng nhập không chính xác. Vui lòng kiểm tra lại.');
      } else {
        setErrorMessage('Đăng nhập thất bại. Vui lòng thử lại.');
      }
      console.error('Đăng nhập thất bại:', error);
    }
  };
  
    return (
    <div className="container-fluid login-page d-flex align-items-center justify-content-center">
      <div className="row w-100">
        <div className="col-md-6 d-flex justify-content-center align-items-center login-left">
          <LogoSection 
            logoImage={logoImage}
            altText="Multi Aura" 
          />
        </div>
        <div className="col-md-6 login-right">
          <LoginForm onSubmit={handleLogin} />
          {errorMessage && <p className="text-danger text-center">{errorMessage}</p>} {/* Hiển thị thông báo lỗi */}

        </div>
      </div>
    </div>
  );
}
  
export default LoginPage;
