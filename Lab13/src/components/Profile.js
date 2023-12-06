import React from 'react';
import styled from 'styled-components';
import useAuthUser from './UserService';

const Profile = () => {
  const userInfo = useAuthUser();

  return (
    <Container>
      <h2>My Profile Details</h2>
      <Section>
        <ul>
          <li>Email: {userInfo?.email}</li>
          <li>Full Name: {userInfo?.name}</li>
        </ul>
      </Section>
    </Container>
  );
};

const Container = styled.div`
  width: 60%;
  margin: 20px auto;
  background-color: #fff;
  padding: 20px;
  border-radius: 8px;
  box-shadow: 0 0 10px rgba(0, 0, 0, 0.1);
`;

const Section = styled.section`
  & ul {
    list-style: none;
    padding: 0;
  }

  & li {
    font-size: 1rem;
    margin-bottom: 10px;
  }
`;

export default Profile;

