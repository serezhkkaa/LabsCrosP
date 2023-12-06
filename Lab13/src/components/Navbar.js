import { Link } from "react-router-dom";
import styled from "styled-components";
import { useOktaAuth } from "@okta/okta-react";
import { useHistory } from "react-router-dom";

const Navbar = () => {
  const { oktaAuth, authState } = useOktaAuth();
  const history = useHistory();

  const loggingIn = async () =>
    oktaAuth.signInWithRedirect({ originalUri: "/" });

  const loggingOut = async () => oktaAuth.signOut();

  const navigateToLab = (labNo) => {
    history.push(`/lab/${labNo}`);
  };

  return (
    <Section>
      <FlexContainer>
        <StyledLink to="/">
          <h2>Головна</h2>
        </StyledLink>
        {authState?.isAuthenticated ? (
          <Dropdown>
            <button>Лабораторні роботи</button>
            <div className="dropdown-content">
              <a onClick={() => navigateToLab(1)}>Лабораторна 1</a>
              <a onClick={() => navigateToLab(2)}>Лабораторна 2</a>
              <a onClick={() => navigateToLab(3)}>Лабораторна 3</a>
            </div>
          </Dropdown>
        ) : (
          <></>
        )}
      </FlexContainer>
      <ul>
        <li>
          {authState?.isAuthenticated ? (
            <Link to="/profile">Профіль</Link>
          ) : (
            <></>
          )}
        </li>
        <li>
          {authState?.isAuthenticated ? (
            <button onClick={loggingOut}>Вийти</button>
          ) : (
            <button onClick={loggingIn}>Увійти</button>
          )}
        </li>
      </ul>
    </Section>
  );
};

const Section = styled.nav`
  width: 90%;
  margin: 1rem auto;
  display: flex;
  align-items: center;
  justify-content: space-between;
  background-color: #bfc0c0;
  padding: 0.5rem 1rem;
  box-shadow: 0 2px 4px rgba(0, 0, 0, 0.1);

  h2 {
    font-family: 'Montserrat', sans-serif;
    color: #3a3b3c;
  }

  a {
    text-decoration: none;
    color: #3a3b3c;
    transition: color 0.3s ease;
  }

  ul {
    display: flex;
    justify-content: space-between;
    align-items: center;

    li {
      list-style-type: none;
      margin-left: 2rem;

      &:hover {
        a {
          color: #626567;
        }
      }

      button {
        font-family: 'Montserrat', sans-serif;
        font-size: 1rem;
        color: #22223b;
        font-weight: 500;
        cursor: pointer;
        outline: none;
        border: 1px solid #4a4e69;
        background: transparent;
        padding: 0.5rem 1rem;
        border-radius: 0.3rem;
        transition: all 0.3s ease;

        &:hover {
          background-color: #4a4e69;
          color: white;
          border-color: transparent;
        }
      }
    }
  }
`;

const Dropdown = styled.div`
  display: inline-block;
  position: relative;

  > button {
    background-color: #4CAF50;
    color: white;
    padding: 16px;
    font-size: 16px;
    border: none;
    cursor: pointer;
  }

  .dropdown-content {
    display: none;
    position: absolute;
    background-color: #f9f9f9;
    min-width: 160px;
    box-shadow: 0px 8px 16px 0px rgba(0,0,0,0.2);
    z-index: 1;

    a {
      color: black;
      padding: 12px 16px;
      text-decoration: none;
      display: block;

      &:hover {
        background-color: #f1f1f1;
      }
    }
  }

  &:hover .dropdown-content {
    display: block;
  }

  &:hover button {
    background-color: #3e8e41;
  }
`;

const FlexContainer = styled.div`
  display: flex;
  align-items: center; 
`;

const StyledLink = styled(Link)`
  margin-right: 10px;
`;

export default Navbar;
