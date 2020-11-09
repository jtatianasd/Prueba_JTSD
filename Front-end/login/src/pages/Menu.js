import React, { Component } from 'react';
import axios from "axios";
import "bootstrap/dist/css/bootstrap.min.css";
import Cookies from 'universal-cookie';
import { browserHistory } from 'react-router';

const url_base="https://localhost:44313/api/Agencies/";
const url_auth="https://v45hh4g3q5.execute-api.us-east-1.amazonaws.com/Dev/authentication";
const url_post = url_base+'auth/'+'?url_auth='+url_auth;
const url_get=url_base+'agencies/';

class Menu extends Component {
  state={
    data:[],
    token:'',
    form:{
      id: '',
      name: '',
      status: '',
      city: '',
      state: ''
    }
    }
  
  

  peticionPost=async()=>{

   await axios.post(url_post).then(response=>{
    this.setState({token: response.data});
    this.peticionGet();
    }).catch(error=>{
      console.log(error.message);
    })
  }
  cerrarSesion=()=>
  {
    const cookies = new Cookies();

    cookies.remove('id', {path: '/'});
    cookies.remove('firstName', {path: '/'});
    cookies.remove('lastName', {path: '/'});
    cookies.remove('code', {path: '/'});
    cookies.remove('email', {path: '/'});
    cookies.remove('userName', {path: '/'});
    cookies.remove('password', {path: '/'});
    browserHistory.push('/');
    
  }
  peticionGet=()=>{
    axios.get(url_get+'?token='+this.state.token).then(response=>{
      this.setState({data: response.data});
    }).catch(error=>{
      console.log(error.message);
    })
    }
    componentDidMount() {
      this.peticionPost();
    }
    
  
    render(){

    return (
      <div className="App">
      <br /><br /><br />
      <button className="btn btn-danger" onClick={()=>this.cerrarSesion()}>Cerrar Sesión</button>

    <br /><br />
      <table className="table ">
        <thead>
          <tr>
            <th>ID</th>
            <th>Name</th>
            <th>Status</th>
            <th>City</th>
            <th>State</th>
          </tr>
        </thead>
        <tbody>
        {this.state.data.map(agencies=>{
          return(
            <tr style={{ backgroundColor: agencies.status==="Closed" ? "red" : "white" }}  >
          <td>{agencies.id}</td>
          <td>{agencies.name}</td>
          <td>{agencies.status } </td>
          <td>{agencies.city}</td>
          <td>{agencies.state}</td>
          </tr>
          )
        })}
        </tbody>
      </table>
  
        
    </div>
  
  
  
    );
  }
  }
  export default Menu;
  