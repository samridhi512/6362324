import React from 'react';

class Getuser extends React.Component {
  constructor(props) {
    super(props);
    this.state = {
      person: null,
      loading: true
    };
  }

  async componentDidMount() {
    const url = "https://api.randomuser.me/";
    const response = await fetch(url);
    const data = await response.json();

    this.setState({ person: data.results[0], loading: false });

    console.log(data.results[0]);
  }

  render() {
    const { person, loading } = this.state;

    if (loading || !person) {
      return <div style={{ textAlign: 'center' }}>Loading...</div>;
    }

    const fullName = `${person.name.title} ${person.name.first} ${person.name.last}`;
    const imageUrl = person.picture.large;

    return (
      <div style={{
        display: 'flex',
        justifyContent: 'center',
        alignItems: 'center',
        height: '100vh',
        fontFamily: 'Arial'
      }}>
        <div style={{
          backgroundColor: '#f9f9f9',
          padding: '30px',
          borderRadius: '12px',
          textAlign: 'center',
          boxShadow: '0 0 10px rgba(0,0,0,0.1)'
        }}>
          <h2 style={{ fontWeight: 'bold', fontSize: '24px', marginBottom: '20px' }}>
            {fullName}
          </h2>
          <img
            src={imageUrl}
            alt="Profile"
            style={{ width: '150px', height: '150px', borderRadius: '10px' }}
          />
        </div>
      </div>
    );
  }
}

export default Getuser;
