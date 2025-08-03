import React from 'react';

export function OddPlayers(props) {
  const [first, , third, , fifth] = props.players;

  return (
    <div>
      <h2>Odd Players</h2>
      <li>First : {first}</li>
      <li>Third : {third}</li>
      <li>Fifth : {fifth}</li>
      <hr />
    </div>
  );
}

export function EvenPlayers(props) {
  const [, second, , fourth, , sixth] = props.players;

  return (
    <div>
      <h2>Even Players</h2>
      <li>Second : {second}</li>
      <li>Fourth : {fourth}</li>
      <li>Sixth : {sixth}</li>
      <hr />
    </div>
  );
}

const allPlayers = ["Sachin1", "Dhoni2", "Virat3", "Rohit4", "Yuvaraj5", "Raina6"];
const T20Players = ["First Player", "Second Player", "Third Player"];
const RanjiTrophyPlayers = ["Fourth Player", "Fifth Player", "Sixth Player"];
const IndianPlayersMerged = [...T20Players, ...RanjiTrophyPlayers];

const IndianPlayers = () => {
  return (
    <div>
      <OddPlayers players={allPlayers} />
      <EvenPlayers players={allPlayers} />

      <h2>List of Indian Players Merged:</h2>
      <ul>
        {IndianPlayersMerged.map((player, index) => (
          <li key={index}>Mr. {player}</li>
        ))}
      </ul>
    </div>
  );
};

export default IndianPlayers;
