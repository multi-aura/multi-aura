import React, { useState, useEffect } from 'react';
import { FontAwesomeIcon } from '@fortawesome/react-fontawesome';
import { faBars, faSignOutAlt } from '@fortawesome/free-solid-svg-icons';
import { useNavigate } from 'react-router-dom';
import './AdminHeader.css';

const Header = ({ toggleSidebar, isSidebarOpen }) => {
    const navigate = useNavigate();
    const [dataUser, setDataUser] = useState(null);

    useEffect(() => {
        const storedUser = localStorage.getItem('user');
        if (storedUser) {
            setDataUser(JSON.parse(storedUser));
        }
    }, []);
    console.log(dataUser);
    const handleLogout = async () => {
        setDataUser(null);
        navigate('/login');
    };

    return (
        <header className="header d-flex align-items-center justify-content-between p-3 bg-light border-bottom">
            <div className="d-flex align-items-center">
                {!isSidebarOpen && (
                    <button className="btn toggle-sidebar-btn" onClick={toggleSidebar}>
                        <FontAwesomeIcon icon={faBars} />
                    </button>
                )}
            </div>

            <div className="admin-info d-flex align-items-center ml-auto dropdown">
                <div data-bs-toggle="dropdown" className='admin-header'>
                    <img
                        src={dataUser?.data?.avatar || 'https://res.cloudinary.com/dlym0sypp/image/upload/v1732856350/profile-photos/profile-photos/1732856349_3ccf02e5-5e71-488c-b428-c36efb22411e.jpg'}
                        alt="Admin Avatar"
                        className="admin-avatar rounded-circle dropdown-toggle"
                        aria-expanded="false"
                    />

                    <span className="admin-name ml-2" >{dataUser?.username || 'Admin'}</span>

                </div>

                <ul className="dropdown-menu custom-dropdown">
                    <li>
                      

                        <button className="dropdown-item" onClick={handleLogout}>
                            <FontAwesomeIcon icon={faSignOutAlt} /> Đăng xuất
                        </button>
                    </li>
                </ul>



            </div>
        </header>
    );
};

export default Header;
